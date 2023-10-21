using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] EnemyHealth _health;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.gameObject.GetComponent<BrainBullet>())
            {
                _health.TakeDamage(1);
            }
        }
    }
}
