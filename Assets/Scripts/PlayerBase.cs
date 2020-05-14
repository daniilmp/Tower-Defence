using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ICanDealDamage>()?.Damage();
            other.GetComponent<IDeath>()?.Death();
        }
    }
}
