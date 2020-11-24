using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ErrMsgPopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Text message;
    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public void SetText(string msg)
    {
        message.text = msg;
    }
}
