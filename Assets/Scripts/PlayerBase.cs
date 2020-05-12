using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<CanDealDamage>()?.Damage();
            other.GetComponent<EnemyDeath>()?.Death();
        }
    }
}
