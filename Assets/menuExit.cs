using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuExit : MonoBehaviour
{
    // variables
    public GameObject[] Panels;
    public GameObject CraftPanel;

    // Start is called before the first frame update
    void Start()
    {
        Panels = GameObject.FindGameObjectsWithTag("PlanetUI");
    }

    void OnMouseDown()
    {
        if (CraftPanel.gameObject.activeSelf == true)
        {
        foreach(GameObject pan in Panels)
        {
            pan.gameObject.SetActive(false);
        }//*/
        CraftPanel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
