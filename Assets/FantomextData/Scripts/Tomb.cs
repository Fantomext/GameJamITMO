using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomb : MonoBehaviour
{
    [SerializeField] private bool _isActive = false;
    [SerializeField] GameObject _hand;
    Color _color;
   
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
        _hand.SetActive(true);
    }


    public void Deactive()
    {
        _isActive = false;
        _hand.SetActive(false);
        
    }
}

