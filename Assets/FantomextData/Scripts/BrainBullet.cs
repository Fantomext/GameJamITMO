using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] Rigidbody _rigibody;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void SetPowerbullet(Vector3 direction)
    {
        _rigibody.AddForce(direction * _bulletSpeed);
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(this.gameObject);
    }


}
