using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMarinePopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public GameObject IF;

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public string GetText()
    {
        return IF.GetComponent<Text>().text;
    }
}
