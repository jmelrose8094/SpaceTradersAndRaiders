using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMinerals : MonoBehaviour
{
    public UnityEngine.UI.Text addMinText;
    public GameObject greenSys;

    private Text greenSysText;
    public int greenSystems;
    public int commonMinerals, rareMinerals, vRareMinerals;

    public void Update()
    {
        greenSysText = greenSys.GetComponent<Text>();
        greenSystems = int.Parse(greenSysText.text);
    }
    
    
    public void clicked()
    {
        commonMinerals += (greenSystems * 30);
        rareMinerals += (greenSystems * 20);
        vRareMinerals += (greenSystems * 10);
        addMinText.text = "Common Minerals: " + commonMinerals + "\nRare Minerals: " + rareMinerals + "\nVery Rare Minerals: " + vRareMinerals;
    }
}
