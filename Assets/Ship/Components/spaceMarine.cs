using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMarine : MonoBehaviour
{
    public int level;

    spaceMarine()
    {
        level = 1;

    }

    spaceMarine(int l)
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


}
