using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform _bulletSpawn;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] BrainBullet _bullet;
    [SerializeField] private bool _isFire = false;
    [SerializeField]
    private InterfaceUI interfaceUI;

    float timer = 0;

    [SerializeField]
    private int ammo = 10;

    private void Start()
    {
        interfaceUI.ChangeBrainText(ammo);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
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
        if (_isFire && ammo > 0)
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
        ammo--;
        RaycastHit hit;

        if (Physics.Raycast(_bulletSpawn.transform.position, _mainCamera.transform.forward, out hit))
        {
            var _bulletPrefab = Instantiate(_bullet, _bulletSpawn.transform.position, _bulletSpawn.rotation);
            _bulletPrefab.SetPowerbullet(_mainCamera.transform.forward);
            interfaceUI.ChangeBrainText(ammo);
        }
    }
}
