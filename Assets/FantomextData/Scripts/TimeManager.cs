using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float time = 5f;
    [SerializeField] private InterfaceUI interfaceUI;
    [SerializeField] private PlayerHealth hpPlayer;

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        interfaceUI.ChangeTimerText(time);
        if (time < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        hpPlayer.Die();
        this.gameObject.SetActive(false);
    }

    public void AddTime(int value)
    {
        time += value;
    }
}
