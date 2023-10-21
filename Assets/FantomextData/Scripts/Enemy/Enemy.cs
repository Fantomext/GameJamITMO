using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    attack,
    patrul,
    chase
}

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    [SerializeField] private Rigidbody _rigibody;

    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] int index = 0;

    [SerializeField] private EnemyState state;

    private void Start()
    {
        state = EnemyState.patrul;
        for (int i = 0; i < wayPoints.Count; i++)
        {
            wayPoints[i].parent = null;
        }
    }
    private void Update()
    {
        if (state == EnemyState.patrul)
        {
            if (Vector3.Distance(transform.position, wayPoints[index].transform.position) > 1)
            {
                Move(wayPoints[index]);
            }
            else
            {
                index++;
                if (index > wayPoints.Count - 1)
                {
                    index = 0;
                }
            }
        }
        if (state == EnemyState.attack)
        {
        }
        if (state == EnemyState.chase)
        {
        }
        
        
    }
    public void Move(Transform targetPositon)
    {
        transform.LookAt(targetPositon);
        _rigibody.velocity = transform.forward * _speed;
    }

    public void Attack(Vector3 playerPosition)
    {
        Debug.Log("attack");
        EnemyAttackState();
        transform.LookAt(playerPosition);

    }

    public void BackPatrul()
    {
        state = EnemyState.patrul;
    }

    public bool IsAttack()
    {
        if (state == EnemyState.attack)
        {
            return true;
        }
        else { return false; }
    }

    public void EnemyAttackState()
    {
        state = EnemyState.attack;
    }
    public void EnemyPatrulState()
    {
        state = EnemyState.patrul;
    }

    public void EnemyChaseState()
    {
        state = EnemyState.chase;
    }
}
