using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_antiMissile : MonoBehaviour
{

    public int level;
    
    public p_antiMissile()
    {
        level = 1;
    }

    public p_antiMissile(int l)
    {
        level = l;
    }

    public int getLevel()
    {
        return level;
    }
}
