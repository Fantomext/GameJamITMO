using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] BrainBullet _bullet;
    [SerializeField] private bool _isFire = false;
    float timer = 0;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isFire = true;
        }
        else
        {
            _isFire = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isFire)
        {
            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
                timer = 0;
                Shoot();

            }
        }
    }

    public void Shoot()
    {
        var _bulletPrefab = Instantiate(_bullet,_bulletSpawn.transform.position, _bulletSpawn.rotation);
        _bulletPrefab.SetPowerbullet(_bulletPrefab.transform.forward);
    }
}
