using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSystem : MonoBehaviour
{
    public UnityEngine.UI.Text sysNum;
    public int playerOneSys = 0, playerTwoSys = 0, pTurn = 1, minerLevel = 0, belongsTo;
    public GameObject turnOrder, pOneMine, pTwoMine;
    public GameObject[] oneMines, twoMines;

    public MineralTracker mineLvl;


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
        {
            pOneMine.SetActive(true);
            belongsTo = 1;
        }
        else if (pTurn == 2)
        {
            pTwoMine.SetActive(true);
            belongsTo = 2;
        }
    }

    public void Update()
    {
        pTurn = turnOrder.GetComponent<EndTurn>().playerNum;
        minerLevel = mineLvl.GetComponent<MineralTracker>().mineLevel[pTurn - 1];

        if (belongsTo == 1 && pTurn == 1)
        {
            oneMines[minerLevel - 1].SetActive(true);
            twoMines[minerLevel - 1].SetActive(false);
        }
        else if (belongsTo == 2 && pTurn == 2)
        {
            twoMines[minerLevel - 1].SetActive(true);
            oneMines[minerLevel - 1].SetActive(false);
        }

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
