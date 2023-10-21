using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigibody;

    [SerializeField] List<Transform> wayPoints = new List<Transform>();
}
