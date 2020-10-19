using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{

    public Text Textfield;
    public GameObject shipRef;
    public PlayerController playerConRef;
    public Vector3 orgPos;

    //Mining Related Variables
    public UnityEngine.UI.Text addMinText;
    public GameObject greenSys;

    private Text greenSysText;
    public int greenSystems;
    public int commonMinerals, rareMinerals, vRareMinerals;


    //Basic function that sets the text of a text box
    public void SetText(string text)
    {
        Textfield.text = text;

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
    }

    //On end of turn, adds the appropriate amount of minerals
    public void clicked()
    {
        commonMinerals += (greenSystems * 30);
        rareMinerals += (greenSystems * 20);
        vRareMinerals += (greenSystems * 10);
        addMinText.text = "Common Minerals: " + commonMinerals + "\nRare Minerals: " + rareMinerals + "\nVery Rare Minerals: " + vRareMinerals;
    }
}
