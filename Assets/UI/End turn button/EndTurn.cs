using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{

    public Text Textfield, turnText;
    public GameObject shipRef;
    public PlayerController playerConRef;
    public Vector3 orgPos;

    public int turnNum = 1;
    public int phaseNum = 1;

    //Mining Related Variables
    public UnityEngine.UI.Text addMinText;
    public GameObject greenSys, redSys, blueSys;

    private Text greenSysText, redSysText, blueSysText;
    public int greenSystems, redSystems, blueSystems;
    public int commonMineralsOne, rareMineralsOne, vRareMineralsOne,commonMineralsTwo, rareMineralsTwo, vRareMineralsTwo;


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
        playerTwo.GetComponent<PlayerController>().enabled = false;

        playerConRef = new PlayerController();
        shipRef = GameObject.Find("p_ship");
        
        orgPos = shipRef.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        print(orgPos.x);
        print(shipRef.transform.position.x);

        //Gets the number of systems owned
        greenSysText = greenSys.GetComponent<Text>();
        greenSystems = int.Parse(greenSysText.text);
        redSysText = redSys.GetComponent<Text>();
        redSystems = int.Parse(redSysText.text);
        blueSysText = blueSys.GetComponent<Text>();
        blueSystems = int.Parse(blueSysText.text);

        /*switch (playerNum)
        {
            case 2:
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo;
                break;
            case 1:
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne;
                break;
        }
        */
    }

    //On end of turn, adds the appropriate amount of minerals
    public void addMineral()
    {
        addMinText.text = "Test";
        switch (playerNum)
        {
            case 2:
                commonMineralsTwo += (greenSystems * 30);
                rareMineralsTwo += (greenSystems * 20) + (blueSystems * 20);
                vRareMineralsTwo += (greenSystems * 10) + (redSystems * 20);
                addMinText.text = "Common Minerals: " + commonMineralsOne + "\nRare Minerals: " + rareMineralsOne + "\nVery Rare Minerals: " + vRareMineralsOne;
                break;
            case 1:
                commonMineralsOne += (greenSystems * 30);
                rareMineralsOne += (greenSystems * 20) + (blueSystems * 20);
                vRareMineralsOne += (greenSystems * 10) + (redSystems * 20);
                addMinText.text = "Common Minerals: " + commonMineralsTwo + "\nRare Minerals: " + rareMineralsTwo + "\nVery Rare Minerals: " + vRareMineralsTwo;
                break;
        }
    }
}
