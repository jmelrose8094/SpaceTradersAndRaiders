using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMarine : MonoBehaviour
{
    public int level;
    public bool active = true;

    public spaceMarine()
    {
        level = 1;

    }

    public spaceMarine(int l)
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

    public void ToggleActive()
    {
        active = !active;
    }

    public bool GetActivity()
    {
        return active;
    }


}
