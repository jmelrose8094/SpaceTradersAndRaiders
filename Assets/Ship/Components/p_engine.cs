﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_engine : Component
{

    //public int level;
    
    public p_engine()
    {
        level = 1;
    }

    public p_engine(int l)
    {
        level = l;
    }

    public override string toString()
    {
        return ("Engine Level: " + level);
    }


}
