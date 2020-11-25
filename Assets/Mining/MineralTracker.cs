using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineralTracker : MonoBehaviour
{
    //Mining Related Variables
    public Text addMinText;
    public GameObject greenSys, redSys, blueSys;

    public Text greenSysText, redSysText, blueSysText;
    public int greenSystems, redSystems, blueSystems;
    public int commonMinerals = 50, rareMinerals = 30, vRareMinerals = 20;
    public int mineLevel = 1;

    public GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    void Update()
    {

        //Gets the number of systems owned
        greenSysText = greenSys.GetComponent<Text>();
        greenSystems = int.Parse(greenSysText.text);
        redSysText = redSys.GetComponent<Text>();
        redSystems = int.Parse(redSysText.text);
        blueSysText = blueSys.GetComponent<Text>();
        blueSystems = int.Parse(blueSysText.text);
    }

    public void UpdateText()
    {
        addMinText.text = "Common Minerals: " + commonMinerals + "\nRare Minerals: " + rareMinerals + "\nVery Rare Minerals: " + vRareMinerals + "\nMines Level: " + mineLevel;
    }

    public void BuyShip()
    {
        //GameObject prefab = new GameObject("humanFrigate");

        //int shipNum = 1;
        //switch (shipNum)
        //{
        //    case 1:
        //        Instantiate(prefab, new Vector3(1f, 1f, 0f), Quaternion.identity);
        //        break;
        //}
    }

    public void addMineral()
    {
        if (mineLevel == 1)
        {
            commonMinerals += (greenSystems * 30) + 50;
            rareMinerals += (greenSystems * 20) + (blueSystems * 40) + 30;
            vRareMinerals += (greenSystems * 10) + (redSystems * 30) + 20;
        }
        else if (mineLevel == 2)
        {
            commonMinerals += (greenSystems * 60) + 100;
            rareMinerals += (greenSystems * 40) + (blueSystems * 80) + 60;
            vRareMinerals += (greenSystems * 20) + (redSystems * 60) + 40;
        }
        else if (mineLevel == 3)
        {
            commonMinerals += (greenSystems * 90) + 150;
            rareMinerals += (greenSystems * 60) + (blueSystems * 120) + 90;
            vRareMinerals += (greenSystems * 30) + (redSystems * 80) + 60;
        }
        else if (mineLevel == 4)
        {
            commonMinerals += (greenSystems * 120) + 200;
            rareMinerals += (greenSystems * 80) + (blueSystems * 160) + 120;
            vRareMinerals += (greenSystems * 40) + (redSystems * 120) + 80;
        }
    }


    public void UpgradeMiner()
    {
        if (mineLevel < 4)
        {
            if (commonMinerals >= 150 && rareMinerals >= 20 && vRareMinerals >= 10)
            {
                mineLevel += 1;
                commonMinerals -= 150;
                rareMinerals -= 20;
                vRareMinerals -= 10;
            }
        }
    }

    public void BuyEngine()
    {
        if (commonMinerals >= 30 && rareMinerals >= 10)
        {
            commonMinerals -= 30;
            rareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyEngine(1);
        }
    }
    public void BuyShieldGen()
    {
        if (commonMinerals >= 10 && rareMinerals >= 20 && vRareMinerals >= 10)
        {
            commonMinerals -= 10;
            rareMinerals -= 20;
            vRareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyShieldGen(1);
        }
    }
    public void BuyRepairSys()
    {
        if (commonMinerals >= 50 && rareMinerals >= 40 && vRareMinerals >= 30)
        {
            commonMinerals -= 50;
            rareMinerals -= 40;
            vRareMinerals -= 30;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyRepairSys(1);
        }
    }
    public void BuyCommandSys()
    {
        if (commonMinerals >= 20 && rareMinerals >= 10 && vRareMinerals >= 10)
        {
            commonMinerals -= 20;
            rareMinerals -= 10;
            vRareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyCommandSys();
        }
    }
    public void BuyMissileLaunch()
    {
        if (commonMinerals >= 20 && rareMinerals >= 10)
        {
            commonMinerals -= 20;
            rareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyMissileLauncher(1);
        }
    }
    public void BuyAntiMissile()
    {
        if (commonMinerals >= 30 && rareMinerals >= 20 && vRareMinerals >= 10)
        {
            commonMinerals -= 30;
            rareMinerals -= 20;
            vRareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyAntiMissile(1);
        }
    }
    public void BuyBeamWeap()
    {
        if (commonMinerals >= 30 && rareMinerals >= 30 && vRareMinerals >= 10)
        {
            commonMinerals -= 30;
            rareMinerals -= 30;
            vRareMinerals -= 10;
            gameController.GetActiveShip().GetComponent<p_ship>().BuyBeamWep(1);
        }
    }
}
