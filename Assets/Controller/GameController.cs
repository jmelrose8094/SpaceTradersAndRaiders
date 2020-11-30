using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> playerOneShips = new List<GameObject>();
    public List<GameObject> playerTwoShips = new List<GameObject>();

    public GameObject activeShip, activeTarget, previousShip;

    public int playerTurnNum, fazeNum;

    public MineralTracker playerOneMineral;
    public MineralTracker playerTwoMineral;


    void Start()
    {

        RecompileList();

        activeShip = playerOneShips[0];
        activeTarget = playerTwoShips[0];
        previousShip = playerTwoShips[0];

        playerTurnNum = 1;
        fazeNum = 1;

    }

    // Update is called once per frame
    void Update()
    {
        playerTurnNum = GetComponent<EndTurn>().turnNum;
        fazeNum = GetComponent<EndTurn>().fazeNum;
        activeShip.GetComponent<PlayerController>().enabled = true;
        previousShip.GetComponent<PlayerController>().enabled = false;

    }

    public void SwitchTurns()
    {
        switch (playerTurnNum)
        {
            case 1:
                previousShip = activeShip;
                activeShip = playerTwoShips[0];
                activeTarget = previousShip;
                break;
            case 2:
                previousShip = activeShip;
                activeShip = playerOneShips[0];
                activeTarget = previousShip;
                break;

        }
    }

    public void RecompileList()
    {
        foreach (GameObject shipObj in GameObject.FindGameObjectsWithTag("p1"))
        {
            playerOneShips.Add(shipObj);
        }
        foreach (GameObject shipObj in GameObject.FindGameObjectsWithTag("p2"))
        {
            playerTwoShips.Add(shipObj);
        }
    }

    public List<GameObject> GetPlayerOneShips()
    {
        return playerOneShips;
    }

    public List<GameObject> GetPlayerTwoShips()
    {
        return playerTwoShips;
    }

    public void ShipAttack()
    {
        activeShip.GetComponent<p_ship>().LaunchAttack(activeTarget.GetComponent<p_ship>());
    }

    public void ShipAssault()
    {
        activeShip.GetComponent<p_ship>().LaunchMarineAssault(activeTarget.GetComponent<p_ship>());
    }

    public void addMineral()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.addMineral(0);
                break;
            case 2:
                playerTwoMineral.addMineral(1);
                break;
        }
    }

    public void UpgradeMiner()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.UpgradeMiner(0);
                break;
            case 2:
                playerTwoMineral.UpgradeMiner(1);
                break;
        }
    }

    public void BuyShip()
    {
        playerOneMineral.BuyShip();
    }

    public void BuyEngine()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyEngine(0);
                break;
            case 2:
                playerTwoMineral.BuyEngine(1);
                break;
        }
    }

    public void BuyShieldGen()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyShieldGen(0);
                break;
            case 2:
                playerTwoMineral.BuyShieldGen(1);
                break;
        }
    }

    public void BuyRepairSys()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyRepairSys(0);
                break;
            case 2:
                playerTwoMineral.BuyRepairSys(1);
                break;
        }
    }

    public void BuyCommandSys()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyCommandSys(0);
                break;
            case 2:
                playerTwoMineral.BuyCommandSys(1);
                break;
        }
    }

    public void BuyMissileLaunch()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyMissileLaunch(0);
                break;
            case 2:
                playerTwoMineral.BuyMissileLaunch(1);
                break;
        }
    }

    public void BuyAntiMissile()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyAntiMissile(0);
                break;
            case 2:
                playerTwoMineral.BuyAntiMissile(1);
                break;
        }
    }

    public void BuyBeamWeap()
    {
        switch (playerTurnNum)
        {
            case 1:
                playerOneMineral.BuyBeamWeap(0);
                break;
            case 2:
                playerTwoMineral.BuyBeamWeap(1);
                break;
        }
    }
   

    public int GetTurnFaze()
    {
        return fazeNum;
    }

    public void SetActiveShip(GameObject shipRef)
    {
        switch (playerTurnNum)
        {
            case 1:
                if (shipRef.tag == "p1")
                {
                    previousShip = activeShip;
                    activeShip = shipRef;
                }
                else if(shipRef.tag == "p2")
                {
                    activeTarget = shipRef;
                }
                break;
            case 2:
                if (shipRef.tag == "p1")
                {
                    activeTarget = shipRef;
                }
                else if (shipRef.tag == "p2")
                {
                    previousShip = activeShip;
                    activeShip = shipRef;
                }
                break;
        }
    }

    public GameObject GetActiveShip()
    {
        return activeShip;
    }
}
