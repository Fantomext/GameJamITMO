using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] EnemyBullet _bullet;
    [SerializeField] Transform _position;

    public void SpawnPrefab()
    {
        Instantiate(_bullet, _position.transform.position, _position.rotation);
    }
}
