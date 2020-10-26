using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_missileLauncher : MonoBehaviour
{

    public int level;
  
    public p_missileLauncher()
    {
        level = 1;
    }

    public p_missileLauncher(int l)
    {
        level = l;
    }

     public int getLevel()
    {
        return level;
    }
}
