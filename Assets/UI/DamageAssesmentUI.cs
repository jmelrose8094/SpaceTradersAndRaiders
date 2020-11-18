using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageAssesmentUI : MonoBehaviour
{
    public GameObject popUpBox;
    public Text armor, critHits, disabledComp;

    public void PopUp()
    {
        popUpBox.SetActive(true);
    }

    public void Close()
    {
        popUpBox.SetActive(false);
    }

    public void SetArmorText(int a)
    {
        armor.text = a.ToString();
    }

    public void SetCritText(int c)
    {
        critHits.text = c.ToString();
    }

    public void SetDisabledComponents(string dc)
    {
        disabledComp.text = dc.ToString();
    }
}
