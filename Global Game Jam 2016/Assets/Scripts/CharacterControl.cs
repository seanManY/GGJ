using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private int health = 3;
    public bool grounded = true;

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

    private int waterCount    = 0;
    private int fireCount     = 0;
    private int airCount      = 0;

    
    // rigidbody.constraints = RigidBodyConstraints.FreezePositionY;
	// Use this for initialization
	void Start () 
    {
        state = State.normal;
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
       
        //Debug.Log(state);
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, -gravity, 0);
        if (Input.GetKeyDown("space"))
            Jump();
	}

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int delta)
    {
        health += delta;
    }

    public int getFire()
    {
        return fireCount;
    }

    public int getAir()
    {
        return airCount;
    }

    public int getWater()
    {
        return waterCount;
    }

    void Jump()
    {
        if (state == State.normal)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, jumpHeight, 0);
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
            if(fireCount < 3)
                fireCount++;
        }

        if (collision.gameObject.tag == "water")
        {
            Destroy(collision.gameObject);
            if (waterCount < 3)
                waterCount++;
        }

        if (collision.gameObject.tag == "air")
        {
            Destroy(collision.gameObject);
            if (airCount < 3)
                airCount++;
        }
     }
}
