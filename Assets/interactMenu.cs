using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class interactMenu : MonoBehaviour
{

    //public GameObject PlanetUI;
    public GameObject[] Panels;
    public GameObject CraftPanel;

    // Start is called before the first frame update
    void Start()
    {
        Panels = GameObject.FindGameObjectsWithTag("PlanetUI");
    }

    void OnMouseDown()
    {
        //Panel.SetActive();
        foreach(GameObject pan in Panels)
        {
            pan.gameObject.SetActive(true);
        }//*/
    }
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton(0).position == PlanetButton.transform.position)
        {
            PlanetUI.setActive(true);
        }*/
    }
}
//*/