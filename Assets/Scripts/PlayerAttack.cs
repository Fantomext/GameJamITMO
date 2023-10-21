using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 2f;
    public int attackDamage = 10;
    public LayerMask enemyLayer;

    public AudioSource batMissSource;
    public AudioSource batAttackSource;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            PerformAttack();
        }
    }

    //повесить на анимацию(если она будет)
    public void PerformAttack()
    {
        RaycastHit hit;
        if (Physics.SphereCast(attackPoint.position, attackRange / 2, transform.forward, out hit, attackRange))
        {
            Collider collider = hit.collider;

            if (collider.attachedRigidbody.gameObject.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.TakeDamage(1);
                batAttackSource.Play();
            }
            else
            {
                batMissSource.Play();
            }

            //var damagable = hit.collider.GetComponent<IDamagable>();
            //if (damagable != null)
            //{
            //    damagable.TakeDamage(attackDamage);
            //}
        }
        else
            batMissSource.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange / 2);
    }
}
