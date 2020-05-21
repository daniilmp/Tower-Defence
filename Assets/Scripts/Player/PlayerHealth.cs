using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action<float> HealthChanged;


    [SerializeField] private float health = 20;
    public float Health { get => health; }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        HealthChanged(health);
    }
}
