using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public void Die()
    {
        Debug.Log("die");
    }
}
