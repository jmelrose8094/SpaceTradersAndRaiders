using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> playerOneShips = new List<GameObject>();
    public List<GameObject> playerTwoShips = new List<GameObject>();

    public GameObject activeShip;

    public int playerTurnNum, fazeNum;

    public MineralTracker playerOneMineral;
    public MineralTracker playerTwoMineral;


    void Start()
    {

        foreach (GameObject shipObj in GameObject.FindGameObjectsWithTag("p1"))
        {
            playerOneShips.Add(shipObj);
        }
        foreach (GameObject shipObj in GameObject.FindGameObjectsWithTag("p2"))
        {
            playerTwoShips.Add(shipObj);
        }

        activeShip = playerOneShips[0];

        playerTurnNum = 1;
        fazeNum = 1;

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(playerTurnNum == 1)
    //    {
    //        playerOneMineral.UpdateText();
    //    }
    //    else if(playerTurnNum == 2)
    //    {
    //        playerTwoMineral.UpdateText();
    //    }
    //}

    public List<GameObject> GetPlayerOneShips()
    {
        return playerOneShips;
    }

    public List<GameObject> GetPlayerTwoShips()
    {
        return playerTwoShips;
    }

    public void addMineral()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.addMineral();
                break;
            case 2:
                playerTwoMineral.addMineral();
                break;
        }
    }

    public void UpgradeMiner()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.UpgradeMiner();
                break;
            case 2:
                playerTwoMineral.UpgradeMiner();
                break;
        }
    }

    public void BuyEngine()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyEngine();
                break;
            case 2:
                playerTwoMineral.BuyEngine();
                break;
        }
    }

    public void BuyShieldGen()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyShieldGen();
                break;
            case 2:
                playerTwoMineral.BuyShieldGen();
                break;
        }
    }

    public void BuyRepairSys()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyRepairSys();
                break;
            case 2:
                playerTwoMineral.BuyRepairSys();
                break;
        }
    }

    public void BuyCommandSys()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyCommandSys();
                break;
            case 2:
                playerTwoMineral.BuyCommandSys();
                break;
        }
    }

    public void BuyMissileLaunch()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyMissileLaunch();
                break;
            case 2:
                playerTwoMineral.BuyMissileLaunch();
                break;
        }
    }

    public void BuyAntiMissile()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyAntiMissile();
                break;
            case 2:
                playerTwoMineral.BuyAntiMissile();
                break;
        }
    }

    public void BuyBeamWeap()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyBeamWeap();
                break;
            case 2:
                playerTwoMineral.BuyBeamWeap();
                break;
        }
    }
    public int GetPlayerTurnNum()
    {
        return playerTurnNum;
    }

    public int GetTurnFaze()
    {
        return fazeNum;
    }

    public GameObject GetActiveShip()
    {
        return activeShip;
    }
}
