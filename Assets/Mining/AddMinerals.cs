using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMinerals : MonoBehaviour
{
    public UnityEngine.UI.Text addMinText;
    public GameObject greenSys, redSys, blueSys;

    private Text greenSysText, redSysText, blueSysText;
    public int greenSystems, redSystems, blueSystems;
    public static int commonMinerals, rareMinerals, vRareMinerals;

    public void Update()
    {
        greenSysText = greenSys.GetComponent<Text>();
        greenSystems = int.Parse(greenSysText.text);
        redSysText = redSys.GetComponent<Text>();
        redSystems = int.Parse(redSysText.text);
        blueSysText = redSys.GetComponent<Text>();
        blueSystems = int.Parse(blueSysText.text);
    }
    
    
    public void clicked()
    {
        commonMinerals += (greenSystems * 30);
        rareMinerals += (greenSystems * 20) + (blueSystems * 20);
        vRareMinerals += (greenSystems * 10) + (redSystems * 20);
        addMinText.text = "Common Minerals: " + commonMinerals + "\nRare Minerals: " + rareMinerals + "\nVery Rare Minerals: " + vRareMinerals;
    }
}
