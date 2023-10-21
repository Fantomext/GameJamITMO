using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceUI : MonoBehaviour
{
    Image hpBar;
    Image energyBar;
    TMP_Text brainText;
    TMP_Text timer;
    TMP_Text successDelivery;

    public void ChangeHpBar(int value)
    {
        hpBar.fillAmount = hpBar.fillAmount + value;
    }

    public void ChangeEnergyBar(int value)
    {
        energyBar.fillAmount = energyBar.fillAmount + value;
    }

    public void ChangeBrainText(string value)
    {
        brainText.text = value;
    }
    public void ChangeTimerText(string value)
    {
        timer.text = value;
    }
    public void ChangeDeliveryCountText(string value)
    {
        successDelivery.text = value;
    }
}
