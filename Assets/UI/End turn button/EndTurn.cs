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
    public Vector3 orgPos;
    
    //Basic function that sets the text of a text box
    public void SetText(string text)
    {
        Textfield.text = text;

    }

    public void resetShip()
    {
        shipRef.transform.position = orgPos;
    }

    //public void IncTurn()
    //{

    //}

    // Start is called before the first frame update
    void Start()
    {

        shipRef = GameObject.Find("p_ship");
        orgPos = shipRef.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        print(orgPos.x);
        print(shipRef.transform.position.x);
        
    }
}
