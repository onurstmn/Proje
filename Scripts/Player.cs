using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{


    //public GameObject cam;
    public GameObject vectorback;
    public GameObject vectorforward;

    private Rigidbody rb;

    private Touch touch;
    [Range(20, 40)]
    public int speedModifier;
    public int forwardSpeed;

    private bool speedballforward = false;
    private bool firsttouchcontrol = false;

    private int soundlimitcount;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Variables.firsttouch == 1 && speedballforward == false)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);


        }
        else if (touch.phase == TouchPhase.Moved)
        {

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                      transform.position.y,
                      touch.deltaPosition.y * speedModifier * Time.deltaTime);



            }
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            rb.velocity = Vector3.zero;
        }


        
    }
}
       
            

           
    

