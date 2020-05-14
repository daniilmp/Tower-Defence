using UnityEngine;
public class MoveOnPath : MonoBehaviour, IMoveOnPath
{
    public float Speed { get => speed; set { speed = value; } }

    [SerializeField] private float speed = 5f, rotationSpeed = 3f;
    private int _currentNodeIndex = 0;
    private Transform _target;
    private bool _isAlive = true;
    private IPath _path = null;

    private void Start()
    {
        _target = _path.PathNodes[_currentNodeIndex];
    }
    public void Initialize(IPath path)
    {
        _path = path;
    }
    private void Update()
    {
        if (_isAlive)
        {
            Vector3 moveDirection = (_target.position - transform.position).normalized;
            MoveToNode(moveDirection);
            LookAtNode(moveDirection);
            if (Vector3.Distance(transform.position, _path.PathNodes[_currentNodeIndex].position) <= 0.05f)
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
        if (_currentNodeIndex >= _path.PathNodes.Count)
        {
            _isAlive = false;
        }
        else
        {
            _target = _path.PathNodes[_currentNodeIndex];
        }

    }
}

