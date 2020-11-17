using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollPopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Text roll1, roll2, p1_text, p2_text, firing;

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public void SetAttackerText(int roll)
    {
        roll1.text = roll.ToString();
    }

    public void SetDefenderText(int level)
    {
        roll2.text = level.ToString();
    }

    public void SetP1_Text(string text)
    {
        p1_text.text = text;
    }

    public void SetP2_Text(string text)
    {
        p2_text.text = text;
    }

    public void SetFiringText(string text)
    {
        firing.text = text;
    }

}
