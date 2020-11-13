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
    public int phaseNum = 1, fazeNum = 0;

    //Mining Related Variables
    public Text addMinText;
    public GameObject greenSys, redSys, blueSys;

    public Text greenSysText, redSysText, blueSysText;
    public int greenSystems, redSystems, blueSystems;
    public int commonMineralsOne = 50, rareMineralsOne = 30, vRareMineralsOne = 20, commonMineralsTwo = 50, rareMineralsTwo = 30, vRareMineralsTwo = 20;
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

        if (playerNum == 2 && phaseNum == 1)
            fazeNum = 2;
        else if (playerNum == 1 && phaseNum == 2)
            fazeNum = 1;
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
            if (playerNum == 2 && fazeNum == 1)
            {
                if (mineLevelOne == 1)
                {
                    commonMineralsOne += (greenSystems * 30)+ 50;
                    rareMineralsOne += (greenSystems * 20) + (blueSystems * 40) + 30;
                    vRareMineralsOne += (greenSystems * 10) + (redSystems * 30) + 20;
                }
                if (mineLevelOne == 2)
                {
                    commonMineralsOne += (greenSystems * 60) + 100;
                    rareMineralsOne += (greenSystems * 40) + (blueSystems * 80) + 60;
                    vRareMineralsOne += (greenSystems * 20) + (redSystems * 60) + 40;
                }
                if (mineLevelOne == 3)
                {
                    commonMineralsOne += (greenSystems * 90) + 150;
                    rareMineralsOne += (greenSystems * 60) + (blueSystems * 120) + 90;
                    vRareMineralsOne += (greenSystems * 30) + (redSystems * 80) + 60;
                }
                if (mineLevelOne == 4)
                {
                    commonMineralsOne += (greenSystems * 120) + 200;
                    rareMineralsOne += (greenSystems * 80) + (blueSystems * 160) + 120;
                    vRareMineralsOne += (greenSystems * 40) + (redSystems * 120) + 80;
                }
            fazeNum = 0;
            }

            if (playerNum == 1 && fazeNum == 2)
            { 
                if (mineLevelTwo == 1)
                {
                    commonMineralsTwo += (greenSystems * 30) + 50;
                    rareMineralsTwo += (greenSystems * 20) + (blueSystems * 40) + 30;
                    vRareMineralsTwo += (greenSystems * 10) + (redSystems * 30) + 20;
                }
                if (mineLevelTwo == 2)
                {
                    commonMineralsTwo += (greenSystems * 60) + 100;
                    rareMineralsTwo += (greenSystems * 40) + (blueSystems * 80) + 60;
                    vRareMineralsTwo += (greenSystems * 20) + (redSystems * 60) + 40;
                }
                if (mineLevelTwo == 3)
                {
                    commonMineralsTwo += (greenSystems * 90) + 150;
                    rareMineralsTwo += (greenSystems * 60) + (blueSystems * 120) + 90;
                    vRareMineralsTwo += (greenSystems * 30) + (redSystems * 80) + 60;
                }
                if (mineLevelTwo == 4)
                {
                    commonMineralsTwo += (greenSystems * 120) + 200;
                    rareMineralsTwo += (greenSystems * 80) + (blueSystems * 160) + 120;
                    vRareMineralsTwo += (greenSystems * 40) + (redSystems * 120) + 80;
                }
            fazeNum = 0;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNum == 2)
            addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo + "\nMines Level: " + mineLevelTwo;
        else if(playerNum == 1)
            addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne + "\nMines Level: " + mineLevelOne;


        //Determine if all of a player's ships are destroyed
        if (playerOne == null || playerTwo == null)
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
        if (playerNum == 1 && mineLevelOne < 4)
        {
            if (commonMineralsOne >= 150 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                mineLevelOne += 1;
                commonMineralsOne -= 150;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2 && mineLevelTwo < 4)
        {
            if (commonMineralsTwo >= 150 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                mineLevelTwo += 1;
                commonMineralsTwo -= 150;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
            }
        }
    }
    
    public void BuyEngine()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 10;
            }
        }
    }
    public void BuyShieldGen()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 10 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 10;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 10 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 10;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
            }
        }
    }
    public void BuyRepairSys()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 50 && rareMineralsOne >= 40 && vRareMineralsOne >= 30)
            {
                commonMineralsOne -= 50;
                rareMineralsOne -= 40;
                vRareMineralsOne -= 30;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 50 && rareMineralsTwo >= 40 && vRareMineralsTwo >= 30)
            {
                commonMineralsTwo -= 50;
                rareMineralsTwo -= 40;
                vRareMineralsTwo -= 30;
            }
        }
    }
    public void BuyCommandSys()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 20 && rareMineralsOne >= 10 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 20;
                rareMineralsOne -= 10;
                vRareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 20 && rareMineralsTwo >= 10 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 20;
                rareMineralsTwo -= 10;
                vRareMineralsTwo -= 10;
            }
        }
    }
    public void BuyMissileLaunch()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 20 && rareMineralsOne >= 10)
            {
                commonMineralsOne -= 20;
                rareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 20 && rareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 20;
                rareMineralsTwo -= 10;
            }
        }
    }
    public void BuyAntiMissile()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 20 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 20;
                vRareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 20 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 20;
                vRareMineralsTwo -= 10;
            }
        }
    }
    public void BuyBeamWeap()
    {
        if (playerNum == 1)
        {
            if (commonMineralsOne >= 30 && rareMineralsOne >= 30 && vRareMineralsOne >= 10)
            {
                commonMineralsOne -= 30;
                rareMineralsOne -= 30;
                vRareMineralsOne -= 10;
            }
        }
        else if (playerNum == 2)
        {
            if (commonMineralsTwo >= 30 && rareMineralsTwo >= 30 && vRareMineralsTwo >= 10)
            {
                commonMineralsTwo -= 30;
                rareMineralsTwo -= 30;
                vRareMineralsTwo -= 10;
            }
        }
    }
}
