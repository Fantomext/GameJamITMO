using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] private string _attack = "Attack";

    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackPeriod = 7f;
    [SerializeField] private Enemy _enemy;
    private float _timer = 0;

    void Update()
    {
        if (_enemy.IsAttack())
        {
            _timer += Time.deltaTime;
            if (_timer > _attackPeriod)
            {
                _timer = 0;
                _animator.SetTrigger(_attack);
            }
        }
            
    }
}
