﻿using UnityEngine;
public class MoveOnPath : MonoBehaviour, IMove
{
    public float Speed { get => speed; set { speed = value; } }

    [SerializeField]
    private float speed = 5f, rotationSpeed = 3f;

    private int _currentNodeIndex = 0;
    private Transform _target;
    private bool _isAlive = true;

    private void Start()
    {
        _target = Path.PathNodes[_currentNodeIndex];
    }

    private void Update()
    {
        if (_isAlive)
        {
            Vector3 moveDirection = (_target.position - transform.position).normalized;
            MoveToNode(moveDirection);
            LookAtNode(moveDirection);
            if (Vector3.Distance(transform.position, Path.PathNodes[_currentNodeIndex].position) <= 0.05f)
            {
                GetNextNode();
            }
        }
    }
    private void MoveToNode(Vector3 direction)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
    private void LookAtNode(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, lookRotation.eulerAngles.y, 0), Time.deltaTime * rotationSpeed);
    }
    private void GetNextNode()
    {

        _currentNodeIndex++;
        if (_currentNodeIndex >= Path.PathNodes.Length)
        {
            _isAlive = false;
        }
        else
        {
            _target = Path.PathNodes[_currentNodeIndex];
        }

    }
}

