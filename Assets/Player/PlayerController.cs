using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // TODO: call to player for number of engines and set moveCount
  public float moveSpeed = 5f, moveCount = 1f;
  public Transform movePoint;
  public GameObject ship;
  Vector3 originalPosition;
  
  
  public LayerMask whatStopsMovement;

  public PlayerController()
  {
       //orignalPosition = GameObject.transform.position;
  }
  
  void Start()
  {
        // makes movePoint independant
        //movePoint = GameObject.Find("p_ship").transform;
        movePoint.parent = null;
        originalPosition = movePoint.transform.position;
  }
  
  
  void Update()
  {
    // gets player location
    transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    
    // checks if ship is stationary before moving
    if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
    {
      // checks for horizontal movement and enacts
      if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))== 1f)
      {
        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
      }
      
      // checks for vertical movement and enacts
      if(Mathf.Abs(Input.GetAxisRaw("Vertical"))== 1f)
      {
        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
      }
    }
  }
  
  public void resetShipPosition()
  {
    //Vector3 orginalPosition = gameObject.transform.position;
     //if(other.gameObject.tag == "End")
     //{
         ship.transform.position = originalPosition;
     //}
  }
}
