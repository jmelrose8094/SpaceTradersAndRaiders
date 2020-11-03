using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    protected int level;

    public Component()
    {
        level = 1;
    }

    public Component(int l)
    {
        level = l;
    }
    public int getLevel()
    {
        return level;
    }

    
   
}
