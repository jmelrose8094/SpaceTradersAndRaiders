using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    /* Red: 1,0,0,1
     * Green: 0,1,0,1
     * Blue: 0,0,1,1
     * Yellow: 1,1,0,1
     */

    public int num;
    void Start()
    {
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();
         /*sprite.color = new Color(1f, 1f, 0f, 1f);*/
        num = UnityEngine.Random.Range(1, 100);

        if(num % 4 == 1)
        {
            sprite.color = new Color(1f, 1f, 0f, 1f);
        }
        else if (num % 4 == 2)
        {
            sprite.color = new Color(0f, 1f, 0f, 1f);
        }
        else if (num % 4 == 3)
        {
            sprite.color = new Color(0f, 0f, 1f, 1f);
        }
        else if (num % 4 == 0)
        {
            sprite.color = new Color(1f, 0f, 0f, 1f);
        }


    }
    

}
