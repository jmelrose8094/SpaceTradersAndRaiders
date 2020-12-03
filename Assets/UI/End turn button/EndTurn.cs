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


    //Player Variables
    public GameObject gameController;
    public GameObject playerOne;
    public GameObject playerTwo;
    public int playerNum = 1;

    // Invokes the reset function in the p_ship class for all of a single players ships
    public void ResetShips()
    {
        gameController.GetComponent<GameController>().RecompileList();
        List<GameObject> temp1 = gameController.GetComponent<GameController>().GetPlayerOneShips();
        List<GameObject> temp2 = gameController.GetComponent<GameController>().GetPlayerTwoShips();

        switch (playerNum)
        {
            case 1:
                for (int i = 0; i < (gameController.GetComponent<GameController>().GetPlayerOneShips().Count); i++)
                {
                    temp1[i].GetComponent<p_ship>().Reset();
                }
                break;
            case 2:
                for (int i = 0; i < (gameController.GetComponent<GameController>().GetPlayerTwoShips().Count); i++)
                {
                    temp2[i].GetComponent<p_ship>().Reset();
                }
                break;
        }
        

       
    }

    public void switchPlayer()
    {
        switch (playerNum)
        {
            case 2:
                playerNum = 1;
                turnText.text = "P" + playerNum + "'s Turn";
                break;
            case 1:
                playerNum = 2;
                turnText.text = "P" + playerNum + "'s Turn";
                break;
        }
        gameController.GetComponent<GameController>().SwitchTurns();
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
        playerTwo = GameObject.FindWithTag("p2");
        playerTwo.GetComponent<PlayerController>().enabled = false;

        playerConRef = new PlayerController();
        shipRef = GameObject.Find("p_ship");
        
        orgPos = shipRef.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       /*
        //Determine if all of a player's ships are destroyed
        if (playerOne == null || playerTwo == null)
        {

            print("Game Over!");
        }
        */
    }
    
}
