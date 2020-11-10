using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_missileLauncher : Component
{

    //public int level;
  
    public p_missileLauncher()
    {
        level = 4;
    }

    public p_missileLauncher(int l)
    {
        level = l;
    }

    public override string toString()
    {
        return ("Missile Launcher Level: " + level);
    }


}
