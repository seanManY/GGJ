using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour
{

    // Instance Variables
    public int speed;
    public int life;

    public Material fire;
    public Material water;
    public Material air;

  
    // Use this for initialization
    void Start()
    {
               
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * -speed, 0, 0);

        life--;
        if(life <= 0)
            Destroy(this.gameObject);
    }
    
    // Methods
    public void SetPosition(int posi)
    {
        transform.Translate(0, posi, 0);
    }

    public void setTag(int type)
    {
        switch (type)
        {
            case 0: this.gameObject.tag = "fire";
                    GetComponent<Renderer>().material = fire;
                    break;
            case 1: this.gameObject.tag = "water";
                    GetComponent<Renderer>().material = water;
                    break;
            case 2: this.gameObject.tag = "air";
                    GetComponent<Renderer>().material = air;
                    break;
        }
    }
}
