using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float time = 5f;
    [SerializeField] 


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }

    public void AddTime(int value)
    {
        time += value;
    }
}
