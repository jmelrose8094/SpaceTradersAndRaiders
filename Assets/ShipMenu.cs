using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipMenu : MonoBehaviour
{

    public GameObject[] Panels;
    public GameObject FrigatePanel;

    // Start is called before the first frame update
    void Start()
    {
        Panels = GameObject.FindGameObjectsWithTag("FrigateStats");
    }
    private void Awake()
    {
        foreach(GameObject pan in Panels)
        {
            pan.gameObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        foreach(GameObject pan in Panels)
        {
            pan.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton(0).position == PlanetButton.transform.position)
        {
            PlanetUI.setActive(true);
        }*/
        /*if (FrigatePanel.gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                foreach(GameObject pan in Panels)
                {
                    pan.gameObject.SetActive(false);
                }
            }
        }//*/
    }
}
//*/