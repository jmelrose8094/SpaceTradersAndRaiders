using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_antiMissile : Component
{

    //public int level;
    
    public p_antiMissile()
    {
        level = 1;
    }

    public p_antiMissile(int l)
    {
        level = l;
    }

    public override string toString()
    {
        return ("Anti-Missile Level: " + level);
    }

}
