using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombManager : MonoBehaviour
{
    [SerializeField] List<Necropolis> necropolisList = new List<Necropolis>();
    [SerializeField] TimeManager timeManager;
    int index = 0;

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
            index = randomValue++;
        }
        else
        {
            index = randomValue;
        }
        if (index > necropolisList.Count)
        {
            index = 0;
        }

        necropolisList[index].SetActiveNecropolis();
        timeManager.AddTime(10);

    }
}
