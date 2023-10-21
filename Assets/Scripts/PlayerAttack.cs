using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 2f;
    public int attackDamage = 10;
    public LayerMask enemyLayer;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            PerformAttack();
        }
    }

    //�������� �� ��������(���� ��� �����)
    public void PerformAttack()
    {
        RaycastHit hit;
        if (Physics.SphereCast(attackPoint.position, attackRange / 2, transform.forward, out hit, attackRange))
        {
            Collider collider = hit.collider;

            if (collider.attachedRigidbody.gameObject.TryGetComponent<EnemyHealth>(out var enemy))
            {
                enemy.TakeDamage(1);
            }

            //var damagable = hit.collider.GetComponent<IDamagable>();
            //if (damagable != null)
            //{
            //    damagable.TakeDamage(attackDamage);
            //}
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange / 2);
    }
}
