using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSystem : MonoBehaviour
{
    public UnityEngine.UI.Text sysNum;
    public int sys = 0;
    public int sysPerClick = 1;
    
    public void clicked()
    {
        sys += sysPerClick;
        sysNum.text = " " + sys;
    }
}
