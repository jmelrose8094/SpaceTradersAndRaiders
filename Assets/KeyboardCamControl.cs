using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCamControl : MonoBehaviour
{
    protected int speed = 2;
    protected bool KeyCamOn;
    // Start is called before the first frame update
    void Start()
    {
        KeyCamOn = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (KeyCamOn)
        {

     if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
     }

        }
    }
}
