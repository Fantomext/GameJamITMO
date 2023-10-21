using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] float _distanceToActivate;
    [SerializeField] ActivateAttack _activator;
    private bool _isActive = true;

    private void Start()
    {
        _activator = FindObjectOfType<ActivateAttack>();
        _activator.AddObjectToActivate(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (distance < _distanceToActivate)
        {
            Activate(playerPosition);
        }

    }

    public void Activate(Vector3 playerPosition)
    {
        gameObject.GetComponent<Enemy>().Attack(playerPosition);
    }


    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
}
