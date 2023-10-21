using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUI : MonoBehaviour
{
    [SerializeField]
    Image hpBar;
    [SerializeField]
    Image energyBar;
    [SerializeField]
    TMP_Text brainText;
    [SerializeField]
    TMP_Text timer;
    [SerializeField]
    TMP_Text successDelivery;

    [SerializeField]
    private Color noResourceColor;

    public void ChangeHpBar(int current, int max)
    {
        float percent = (float)current / max;
        hpBar.fillAmount = percent;
    }

    public void ChangeEnergyBar(int value)
    {
        energyBar.fillAmount = value;
    }

    public void ChangeBrainText(int value)
    {
        brainText.text = value.ToString();

        if (value == 0)
            brainText.color = noResourceColor;
    }
    public void ChangeTimerText(float value)
    {
        int seconds = (int)value;
        int mins = seconds / 60;
        int secsElapsed = seconds % 60;

        timer.text = $"{mins:00}:{secsElapsed:00}";
    }
    public void ChangeDeliveryCountText(int value)
    {
        successDelivery.text = value.ToString();
    }
}
