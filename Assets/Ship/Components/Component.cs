using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    protected int level;
    protected bool active = true;

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

    public void setLevel(int l)
    {
        level = l;
    }

    public void ToggleActivity()
    {
        active = !active;
    }
    
    public bool getActivity()
    {
        return active;
    }

    public virtual string toString()
    {
        return ("Component");
    }
}
