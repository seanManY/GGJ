﻿using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private int health = 5;
    public bool grounded = true;
    public GameObject GUI;
    private GameObject gui;

    public enum State
    {
        normal,
        jumping
    }

    public GameObject Power; //reference to power script
    private Power powObj;
   
    public int     jumpHeight = 5;
    public float   gravity    = 3;
    public State   state;

    private int    waterCount = 0;
    private int    fireCount  = 0;
    private int    airCount   = 0;

    public  int    invFrames  = 3;
    private bool   invincible = false;

    
    // rigidbody.constraints = RigidBodyConstraints.FreezePositionY;
	// Use this for initialization
	void Start () 
    {
        state = State.jumping;
        
        Vector3 guiPos = new Vector3(0, 0, 0);
        gui = (GameObject)Instantiate(GUI, guiPos, Quaternion.identity);
        //gui = GUI.GetComponent("GUI") as GUI;
    }

    //Update is called once per frame
    void Update()
    {
        //Debug.Log(grounded);
        //if (Input.GetButton("Jump") && grounded)
        //   gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
    }

    void FixedUpdate () 
    {
       
        //Debug.Log(health);
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, -gravity, 0);
        if (Input.GetKeyDown("space"))
            Jump();

        if(health <= 0)
        {
           // Debug.Log("you are dead");
        }
	}

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int delta)
    {
        health += delta;
    }

    void Jump()
    {
        if (state == State.normal)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, jumpHeight, 0);
            //GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpHeight, 0));
            state = State.jumping;
        }
    }

    //checks if player is touching the floor
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "floor" )
        {
            
            state = State.normal;
        }

        

        //implement UI
        if (collision.gameObject.tag == "fire")
        {
            Destroy(collision.gameObject);
            if (fireCount < 3)
            {
                gui.GetComponent<GUI>().add(fireCount, 0);
                fireCount++;
            }
        }

        if (collision.gameObject.tag == "air")
        {
            Destroy(collision.gameObject);
            if (waterCount < 3)
            {
                gui.GetComponent<GUI>().add(airCount, 1);
                waterCount++;
            }
        }

        if (collision.gameObject.tag == "water")
        {
            Destroy(collision.gameObject);
            if (airCount < 3)
            {
                gui.GetComponent<GUI>().add(waterCount, 2);
                airCount++;
            }
        }
     }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "obstacle")
        {
            if(!invincible)
            {
                health--;
                invincible = true;
                 StartCoroutine(wait());
                invincible = false;
            }
            
           
        }
    }

    //used to wait for seconds
    IEnumerator wait()
    {
        print(Time.time);
        yield return new WaitForSeconds(50000f);
        print(Time.time);
    }
}
