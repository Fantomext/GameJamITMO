using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAttack : MonoBehaviour
{
    [SerializeField] List<ActivateByDistance> objectToActivate = new List<ActivateByDistance>();

    [SerializeField] private Transform _playerTransform;
    private void Update()
    {

        for (int i = 0; i < objectToActivate.Count; i++)
        {
            if (objectToActivate[i] == null)
            {
                objectToActivate.RemoveAt(i);
                continue;
            }

            objectToActivate[i].CheckDistance(_playerTransform.position);
        }

    }

    public void AddObjectToActivate(ActivateByDistance activateByDistance)
    {
        objectToActivate.Add(activateByDistance);
    }

    public void DeleteObjectToActivate(ActivateByDistance activateByDistance)
    {
        objectToActivate.Remove(activateByDistance);
    }
}
