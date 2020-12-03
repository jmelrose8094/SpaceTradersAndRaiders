using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CreateFrigate : MonoBehaviour//: p_ship
{
    public GameObject shipPrefab;
    public int numComponents;

    public void Start()
    {

        GameObject shipPrefab = Resources.Load("Prefab/p_ship_Cruiser") as GameObject;
        /*p_ship frigate = new p_ship(numComponents);
        //frigate.shipObject
        GameObject a = Instantiate(shipPrefab) as GameObject;
        //GameObject a = Resources.Load("Prefab/p_ship_Cruiser") as GameObject;
        a.transform.position = new Vector3(-0.507f, 2.51f, -3);
        //frigate.shipObject = a;//*/
    }
    public void OnClick()
    {
        p_ship frigate = new p_ship(numComponents);
        //frigate.shipObject
       // GameObject a = new GameObject p_ship(numComponents);//) as GameObject;
        //GameObject a = Resources.Load("Prefab/p_ship_Cruiser") as GameObject;
        frigate.transform.position = new Vector3(-0.507f, 2.51f, -3);
        //frigate.shipObject = a;
    }

    /*public CreateFrigate()
    {
        p_ship frigate = new p_ship(numComponents);
        //frigate.shipObject
        GameObject a = Instantiate(shipPrefab) as GameObject;
        //GameObject a = Resources.Load("Prefab/p_ship_Cruiser") as GameObject;
        a.transform.position = new Vector2(-0.507f, 2.51f);
        frigate.shipObject = a;
    }//*/

    /*public void create()
    {
        CreateFrigate();
    }*/
}