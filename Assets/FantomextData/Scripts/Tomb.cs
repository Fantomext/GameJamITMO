using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    [SerializeField] private bool _isActive = false;
    Color _color;
    private void Start()
    {
        _color = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isActive)
        {
            if (collision.rigidbody.gameObject.TryGetComponent<BrainBullet>(out var brainBullet))
            {
                brainBullet.Hit();
                transform.parent.GetComponent<Necropolis>().DeliverySuccess();
            }
        }
    }


    public void SetActive()
    {
        _isActive = true;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }


    public void Deactive()
    {
        _isActive = false;
        gameObject.GetComponent<MeshRenderer>().material.color = _color;
    }
}

