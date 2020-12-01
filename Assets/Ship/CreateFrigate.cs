using System;
using UnityEngine;

public class CreateFrigate : p_ship
{
    public CreateFrigate()
    {
        p_ship frigate = new p_ship(5);
        frigate.shipObject = Instantiate(shipObject, shipObject.transform) as GameObject;
    }

    /*public void create()
    {
        CreateFrigate();
    }*/
}