using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("die");
        Destroy(gameObject);
    }
}
