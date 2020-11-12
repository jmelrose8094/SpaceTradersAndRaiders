using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSystem : MonoBehaviour
{
    public UnityEngine.UI.Text sysNum;
    public int playerOneSys = 0, playerTwoSys = 0, pTurn = 1;
    public GameObject turnOrder, pOneMine, pTwoMine;

    private void Awake()
    {
        turnOrder = GameObject.FindGameObjectWithTag("End Turn");
    }

   
    public void clicked()
    {
        if (pTurn == 1)
        {
            playerOneSys += 1;
        }

        else if (pTurn == 2)
        {
            playerTwoSys += 1;
        }
    }

    public void owned()
    {
        if (pTurn == 1)
            pOneMine.SetActive(true);
        else if (pTurn == 2)
            pTwoMine.SetActive(true);
    }

    public void Update()
    {
        pTurn = turnOrder.GetComponent<EndTurn>().playerNum;

        if (pTurn == 1)
        {
            sysNum.text = " " + playerOneSys;
        }

        if (pTurn == 2)
        {
            sysNum.text = " " + playerTwoSys;
        }
    }
}
