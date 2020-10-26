using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_beamWeapon : MonoBehaviour
{

    public int level;
   
    public p_beamWeapon()
    {
        level = 1;
    }

    public p_beamWeapon(int l)
    {
        level = l;
    }

    public int getLevel()
    {
        return level;
    }
}
