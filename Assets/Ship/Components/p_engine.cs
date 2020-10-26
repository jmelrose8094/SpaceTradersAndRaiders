using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_engine : MonoBehaviour
{

    public int level;
    
    public p_engine()
    {
        level = 1;
    }

    public p_engine(int l)
    {
        level = l;
    }

    public int getLevel()
    {
        return level;
    }
}
