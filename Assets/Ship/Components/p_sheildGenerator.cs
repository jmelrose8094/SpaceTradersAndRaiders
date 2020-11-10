using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class p_sheildGenerator : Component
{

    //public int level;
   
    public p_sheildGenerator()
    {
        level = 1;
    }

    public p_sheildGenerator(int l)
    {
        level = l;
    }

    public override string toString()
    {
        return ("Shield Gen Level: " + level);
    }



}
