using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarineAssaultAssesment : MonoBehaviour
{
    public GameObject popUpBox;
    public Text results;

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public void SetText(string r)
    {
        results.text = r;
    }
}
