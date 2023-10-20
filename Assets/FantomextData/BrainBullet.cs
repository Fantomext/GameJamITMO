using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] Rigidbody _rigibody;

    public void SetPowerbullet(Vector3 direction)
    {
        _rigibody.AddForce(direction * _bulletSpeed);
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }


}
