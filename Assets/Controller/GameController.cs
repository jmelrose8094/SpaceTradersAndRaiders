using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> playerOneShips = new List<GameObject>();
    public List<GameObject> playerTwoShips = new List<GameObject>();

    //public GameObject activeShip;




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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetPlayerOneShips()
    {
        return playerOneShips;
    }

    public List<GameObject> GetPlayerTwoShips()
    {
        return playerTwoShips;
    }
}
