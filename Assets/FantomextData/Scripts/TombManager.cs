using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombManager : MonoBehaviour
{
    [SerializeField] List<Necropolis> necropolisList = new List<Necropolis>();
    [SerializeField] TimeManager timeManager;
    [SerializeField]int index = 0;
    [SerializeField] ArrowLook _arrow;

    private void Start()
    {
        RandomNecropolis();
    }

    [ContextMenu("Next")]
    public void RandomNecropolis()
    {

        int randomValue = Random.Range(0, necropolisList.Count);
        if (randomValue == index)   
        {
            index = randomValue + 1;
        }
        else
        {
            index = randomValue;
        }
        if (index > necropolisList.Count - 1)
        {
            index = 0;
        }

        necropolisList[index].SetActiveNecropolis();
        _arrow.SetTarget(necropolisList[index].GetCoordinates());
        timeManager.AddTime(10);

    }
}
