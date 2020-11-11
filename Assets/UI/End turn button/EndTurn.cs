using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndTurn : MonoBehaviour
{

    public Text Textfield, turnText;
    public GameObject shipRef;
    public PlayerController playerConRef;
    public Vector3 orgPos;

    public int turnNum = 1;
    public int phaseNum = 1;

    //Mining Related Variables
    public Text addMinText;
    public GameObject greenSys, redSys, blueSys;

    public Text greenSysText, redSysText, blueSysText;
    public int greenSystems, redSystems, blueSystems;
    public int commonMineralsOne, rareMineralsOne, vRareMineralsOne, commonMineralsTwo, rareMineralsTwo, vRareMineralsTwo;
    public int mineLevelOne = 1, mineLevelTwo = 1;


    //Player Variables
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerNum = 1;

    public void switchPlayer()
    {
        switch (playerNum)
        {
            case 2:
                playerOne.GetComponent<PlayerController>().enabled = true;
                playerTwo.GetComponent<PlayerController>().enabled = false;
                playerNum = 1;
                turnText.text = "P" + playerNum + "'s Turn";
                break;
            case 1:
                playerTwo.GetComponent<PlayerController>().enabled = true;
                playerOne.GetComponent<PlayerController>().enabled = false;
                playerNum = 2;
                turnText.text = "P" + playerNum + "'s Turn";
                break;
        }
    }


    //Basic function that sets the text of a text box
    public void SetText(string text)
    {
        if ((playerNum == 2) && (phaseNum == 2))
        {
            turnNum += 1;
            phaseNum = 1;
            Textfield.text = "Turn " + turnNum + "\nFirst Phase";
        }
        else if ((playerNum == 2) && (phaseNum == 1))
        {
            phaseNum = 2;
            Textfield.text = "Turn " + turnNum + "\nSecond Phase";
        }
    }

    //Basic Function that resets the position of the ship to its starting position
    public void resetShip()
    {
        shipRef.transform.position = orgPos;
        playerConRef.movePoint.position = orgPos;
    }

    //public void IncTurn()
    //{

    //}

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.FindWithTag("p1");
        playerTwo = GameObject.FindWithTag("ship 2");
        playerTwo.GetComponent<PlayerController>().enabled = false;

        playerConRef = new PlayerController();
        shipRef = GameObject.Find("p_ship");
        
        orgPos = shipRef.transform.position;
        
    }
    //On end of turn, adds the appropriate amount of minerals
    public void addMineral()
    {
        switch (playerNum)
        {
            case 2:
                commonMineralsOne += (greenSystems * 30);
                rareMineralsOne += (greenSystems * 20) + (blueSystems * 20);
                vRareMineralsOne += (greenSystems * 10) + (redSystems * 20);
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
                break;

            case 1:
                commonMineralsTwo += (greenSystems * 30);
                rareMineralsTwo += (greenSystems * 20) + (blueSystems * 20);
                vRareMineralsTwo += (greenSystems * 10) + (redSystems * 20);
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Determine if all of a player's ships are destroyed
        if(playerOne == null || playerTwo == null)
        {

            print("Game Over!");
        }

        //Gets the number of systems owned
        greenSysText = greenSys.GetComponent<Text>();
        greenSystems = int.Parse(greenSysText.text);
        redSysText = redSys.GetComponent<Text>();
        redSystems = int.Parse(redSysText.text);
        blueSysText = blueSys.GetComponent<Text>();
        blueSystems = int.Parse(blueSysText.text);

    }



    public void UpgradeMiner()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 150 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                mineLevelOne += 1;
                commonMineralsOne -= 150;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 150 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                mineLevelTwo += 1;
                commonMineralsTwo -= 150;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    
    public void BuyEngine()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyShieldGen()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 10 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 10;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 10 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 10;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyRepairSys()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 50 && rareMineralsOne >= 40 && vRareMineralsOne >= 30)
            {
                commonMineralsOne -= 50;
                rareMineralsOne -= 40;
                vRareMineralsOne -= 30;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 50 && rareMineralsTwo >= 40 && vRareMineralsTwo >= 30)
            {
                commonMineralsTwo -= 50;
                rareMineralsTwo -= 40;
                vRareMineralsTwo -= 30;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyCommandSys()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 20 && rareMineralsOne >= 10 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 20;
                rareMineralsOne -= 10;
                vRareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 20 && rareMineralsTwo >= 10 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 20;
                rareMineralsTwo -= 10;
                vRareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyMissileLaunch()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 20 && rareMineralsOne >= 10)
            {
                commonMineralsOne -= 20;
                rareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 20 && rareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 20;
                rareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyAntiMissile()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
    public void BuyBeamWeap()
    {
        if (playerNum == 2)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 30 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 30;
                vRareMineralsOne -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMine Level: " + mineLevelOne;
            }
        }
        else if (playerNum == 1)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 30 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 30;
                vRareMineralsTwo -= 10;
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMine Level: " + mineLevelTwo;
            }
        }
    }
}
