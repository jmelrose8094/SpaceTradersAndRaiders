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
    public int greenSystems, redSystems, blueSystems, turn;
    public EndTurn playerTurn;
    public int[] commonMinerals, rareMinerals, vRareMinerals, mineLevel;
    public GameController gameController;

    void Start()
    {
        commonMinerals = new int[] {50, 50};
        rareMinerals = new int[] {30, 30};
        vRareMinerals = new int[] {20, 20};
        mineLevel = new int[] {1, 1};

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

        turn = playerTurn.GetComponent<EndTurn>().playerNum;
        addMinText.text = "    " + commonMinerals[turn - 1] + "\n    " + rareMinerals[turn - 1] + "\n    " + vRareMinerals[turn - 1] + "\nMines Level: " + mineLevel[turn - 1];
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

    public void addMineral(int i)
    {
        if (mineLevel[i] == 1)
        {
            commonMinerals[i] += (greenSystems * 30) + 50;
            rareMinerals[i] += (greenSystems * 20) + (blueSystems * 40) + 30;
            vRareMinerals[i] += (greenSystems * 10) + (redSystems * 30) + 20;
        }
        else if (mineLevel[i] == 2)
        {
            commonMinerals[i] += (greenSystems * 60) + 100;
            rareMinerals[i] += (greenSystems * 40) + (blueSystems * 80) + 60;
            vRareMinerals[i] += (greenSystems * 20) + (redSystems * 60) + 40;
        }
        else if (mineLevel[i] == 3)
        {
            commonMinerals[i] += (greenSystems * 90) + 150;
            rareMinerals[i] += (greenSystems * 60) + (blueSystems * 120) + 90;
            vRareMinerals[i] += (greenSystems * 30) + (redSystems * 80) + 60;
        }
        else if (mineLevel[i] == 4)
        {
            commonMinerals[i] += (greenSystems * 120) + 200;
            rareMinerals[i] += (greenSystems * 80) + (blueSystems * 160) + 120;
            vRareMinerals[i] += (greenSystems * 40) + (redSystems * 120) + 80;
        }
    }


    public void UpgradeMiner(int i)
    {
        if (mineLevel[i] < 4)
        {
            if (commonMinerals[i] >= 150 && rareMinerals[i] >= 20 && vRareMinerals[i] >= 10)
            {
                mineLevel[i] += 1;
                commonMinerals[i] -= 150;
                rareMinerals[i] -= 20;
                vRareMinerals[i] -= 10;
            }
        }
    }

    public void BuyEngine(int i)
    {
        if (commonMinerals[i] >= 30 && rareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 30;
                rareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyEngine(1);
        }
    }
    public void BuyShieldGen(int i)
    {
        if (commonMinerals[i] >= 10 && rareMinerals[i] >= 20 && vRareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 10;
                rareMinerals[i] -= 20;
                vRareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyShieldGen(1);
        }
    }
    public void BuyRepairSys(int i)
    {
        if (commonMinerals[i] >= 50 && rareMinerals[i] >= 40 && vRareMinerals[i] >= 30)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 50;
                rareMinerals[i] -= 40;
                vRareMinerals[i] -= 30;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyRepairSys(1);
        }
    }
    public void BuyCommandSys(int i)
    {
        if (commonMinerals[i] >= 20 && rareMinerals[i] >= 10 && vRareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 20;
                rareMinerals[i] -= 10;
                vRareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyCommandSys();
        }
    }
    public void BuyMissileLaunch(int i)
    {
        if (commonMinerals[i] >= 20 && rareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 20;
                rareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyMissileLauncher(1);
        }
    }
    public void BuyAntiMissile(int i)
    {
        if (commonMinerals[i] >= 30 && rareMinerals[i] >= 20 && vRareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 30;
                rareMinerals[i] -= 20;
                vRareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyAntiMissile(1);
        }
    }
    public void BuyBeamWeap(int i)
    {
        if (commonMinerals[i] >= 30 && rareMinerals[i] >= 30 && vRareMinerals[i] >= 10)
        {
            if (gameController.GetActiveShip().GetComponent<p_ship>().slotsUsed < gameController.GetActiveShip().GetComponent<p_ship>().maxComponents)
            {
                commonMinerals[i] -= 30;
                rareMinerals[i] -= 30;
                vRareMinerals[i] -= 10;
                
            }
            gameController.GetActiveShip().GetComponent<p_ship>().BuyBeamWep(1);
        }
    }
}
