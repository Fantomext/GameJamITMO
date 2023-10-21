using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLook : MonoBehaviour
{
    [SerializeField] private Transform _target;


    private void Update()
    {
        Vector3 position = _target.position;
        position.y = 1.5f;
        transform.LookAt(_target);
  
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
