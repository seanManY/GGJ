using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    private int health = 3;
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
    private int    highlight  = 0;

    public  int    invFrames  = 3;
    private bool   invincible = false;

    public Transform shootPrefab; // position of the shooter
    public GameObject shot;        //the shot prefab

    public float fireRate;
    private float nextFire = 5;
    public int specialFireRate = 6;
    public int airTime = 6;
    
    // rigidbody.constraints = RigidBodyConstraints.FreezePositionY;
	// Use this for initialization
	void Start () 
    {

        state = State.normal;
	
       // state = State.jumping;
        
        Vector3 guiPos = new Vector3(0, 0, 0);
        gui = (GameObject)Instantiate(GUI, guiPos, Quaternion.identity);
        //gui = GUI.GetComponent("GUI") as GUI;
    }


    //Update is called once per frame
    void Update()
    {
        //Debug.Log(health);
        //if (Input.GetButton("Jump") && grounded)
        //   gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);

        if (Input.GetKeyDown(KeyCode.LeftAlt) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }

    void FixedUpdate () 
    {
       
        //Debug.Log(health);
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + new Vector3(0, -gravity, 0);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Jump();
        }
            
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            highlight = (highlight + 2) % 3;
            gui.GetComponent<GUI>().scroll(this.highlight);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            highlight = (highlight + 1) % 3;
            gui.GetComponent<GUI>().scroll(this.highlight);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charged();
        }

        if (health <= 0)
        {
           // Debug.Log("you are dead");
        }
	}

    public void shoot()
    {
        Instantiate(shot, shootPrefab.transform.position, shootPrefab.rotation);
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
            if (airCount < 3)
            {
                gui.GetComponent<GUI>().add(airCount, 1);
                airCount++;
            }
        }

        if (collision.gameObject.tag == "water")
        {
            Destroy(collision.gameObject);
            if (waterCount < 3)
            {
                gui.GetComponent<GUI>().add(waterCount, 2);
                waterCount++;
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
                gui.GetComponent<GUI>().damage(health);
                //if(health <= 0)
                    //Death;
                invincible = true;
                StartCoroutine(wait());
                
            }
            
           
        }

        if(coll.gameObject.tag == "web")
        {
            
            

            if (!invincible)
            {
                health--;
                Debug.Log("Hurt");
                if (health >= 0)
                    gui.GetComponent<GUI>().damage(health);
                //if(health <= 0)
                //Death;
                invincible = true;
                StartCoroutine(wait());
                Destroy(coll.transform.parent.gameObject);

            }

        }

        if (coll.gameObject.tag == "spider")
        {
            
            

            if (!invincible)
            {
                health--;
                if (health >= 0)
                    gui.GetComponent<GUI>().damage(health);
                //if(health <= 0)
                //Death;
                invincible = true;
                StartCoroutine(wait());
                Destroy(coll.gameObject);

            }

        }
    }

    //used to wait for seconds
    IEnumerator wait()
    {
        //print(Time.time);
        yield return new WaitForSeconds(invFrames);
        invincible = false;
        
    }

    //super charged
    public void fireRitual()
    {
        gui.GetComponent<GUI>().empty(0);

        while (Time.time <= specialFireRate)
        {
            fireRate = .00001f;
            fireCount = 0;
        }
    }

    

    public void airRitual()
    {
        gui.GetComponent<GUI>().empty(1);

        while (Time.time <= airTime)
        {
            
            Vector3 movement = new Vector3(-2, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = movement;

            airCount = 0;
        }
        
    }

    public void waterRitual()
    {
        if (health != 3)
        {
            gui.GetComponent<GUI>().empty(2);
            health = 3;
            gui.GetComponent<GUI>().heal();
            waterCount = 0;
        }
    }

    public void charged()
    {
        if (highlight == 0 && fireCount >= 3)
            fireRitual();

        if (highlight == 1 && airCount >= 3)
            airRitual();

        if (highlight == 2 && waterCount >= 3)
            waterRitual();
    }
}
