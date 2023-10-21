using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necropolis : MonoBehaviour
{
    [SerializeField] List <Tomb> tombs = new List <Tomb> ();
    [SerializeField] TombManager tombManager;
    [SerializeField] private bool _active = false;
    [SerializeField] private Transform _coordinate;
    [SerializeField] Color _color;


    public void SetActiveNecropolis()
    {
        _active = true;
        int index = UnityEngine.Random.Range(0, tombs.Count);

            Debug.Log(index);
            for (int i = 0; i < tombs.Count; i++)
            {
                tombs[i].Deactive();
            }
            tombs[index].SetActive();
    }

    public void DeactivateNecrolopis()
    {
        _active = false;
        for (int i = 0; i < tombs.Count; i++)
        {
            tombs[i].Deactive();
        }
    }

    public void DeliverySuccess()
    {
        DeactivateNecrolopis();
        tombManager.RandomNecropolis();
    }

    public Transform GetCoordinates()
    {
        return _coordinate;
    }

}
