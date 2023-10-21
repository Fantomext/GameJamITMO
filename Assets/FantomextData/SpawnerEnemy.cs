using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField]private Enemy enemy;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private List<Transform> _targets = new List<Transform>();

    [ContextMenu("eaa")]
    public void Spawn()
    {
        Instantiate(enemy, _spawnPosition.transform.position,_spawnPosition.rotation);
    }

    public void Move()
    {
        _rigibody.AddForce(transform.forward * 15f);

        //for (int i = 0; i < length; i++)
        //{

        //}
        //transform.rotation.SetLookRotation(_targets)
    }
}
