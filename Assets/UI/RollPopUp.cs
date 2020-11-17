using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollPopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Text text1, text2;

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public void SetAttackerText(float roll)
    {
        text1.text = roll.ToString();
    }

    public void SetDefenderText(int level)
    {
        text2.text = level.ToString();
    }

}
