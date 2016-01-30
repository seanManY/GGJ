using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private int health = 3;

    public enum State
    {
        normal,
        jumping
    }
   
    public int     jumpHeight = 5;
    public float   gravity = 3;
    public State state;

    
    // rigidbody.constraints = RigidBodyConstraints.FreezePositionY;
	// Use this for initialization
	void Start () 
    {
        state = State.normal;
	}
	
	//Update is called once per frame
	void Update () 
    {

        Debug.Log(state);
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
     }
}
