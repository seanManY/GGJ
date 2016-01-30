using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    // Instance Variables
    private CharacterControl player;

    
    // Use this for initialization
	void Start ()
    {
        player = gameObject.GetComponentInParent<CharacterControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Enter");
        player.grounded = true;
    }

    void OnCollisionStay(Collision col)
    {
        Debug.Log("Stay");
        player.grounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        player.grounded = false;
    }
}
