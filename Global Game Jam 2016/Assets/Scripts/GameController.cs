using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Instance Variables
    public GameObject floor;
    public GameObject player;
    public GameObject obstacle;
    public GameObject spider;
    public int maxRange = 5;

    private int random;

    public int rate = 10;
    private int time;

    public int wRate = 20;
    private int wTime;

    private GameObject POWER;
    public  GameObject power;

    public GameObject fire;
    public GameObject wind;
    public GameObject water;

    public GameObject background;

    private bool block;
    private GameObject last;

    public float ranRate;
    private float ranTime;

	// Use this for initialization
	void Start () 
    {
        time = rate;
        ranTime = ranRate;
        block = true;
        //background
        for (int i = -1; i < 3; i++)
        {
            Vector3 backGroundPos = new Vector3(32 * i, .5f * i, -3);
            Instantiate(background, backGroundPos, Quaternion.identity);
        }
        

        //player
        Vector3 playerPos = new Vector3(-4, 5, 0);
        Instantiate(player, playerPos, Quaternion.identity);

        for (int i = 0; i < 50; i++)
        {
            //the floor initial
            Vector3 floorPos = new Vector3(15-i, 0, 0);
            Instantiate(floor, floorPos, Quaternion.identity);
        }
	}

    // Update is called once per frame
    void FixedUpdate() 
    {
        random = Random.Range(0, 100);
        time--;
        if (time < 0)
        {
            
            //floor generator
            Vector3 floorPos = new Vector3(15, 0, 0);
            Instantiate(floor, floorPos, Quaternion.identity);


            time = rate;
            ranTime--;
            if (ranTime < 0)
            {

                if (random <= 25)
                {
                    //power ups
                    int powRandHeight = Random.Range(2, maxRange);
                    Vector3 powerPos = new Vector3(15, powRandHeight, 0);
                    int powRandom = Random.Range(0, 3);
                    Debug.Log(powRandom);
                    switch (powRandom)
                    {
                        case 0: POWER = (GameObject)Instantiate(fire, powerPos, Quaternion.Euler(90,0,0));
                                POWER.GetComponent<Power>().setTag(powRandom);
                                break;
                        case 1: POWER = (GameObject)Instantiate(water, powerPos, Quaternion.Euler(-90, 0, 0));
                                POWER.GetComponent<Power>().setTag(powRandom);
                                break;
                        case 2: POWER = (GameObject)Instantiate(wind, powerPos, Quaternion.Euler(90, 0, 0) );
                                POWER.GetComponent<Power>().setTag(powRandom);
                                break;
                    }
                    
                    
                    block = false;
                    ranTime = ranRate;
                }
                //obtacle, spikes
                else if (random <= 55)
                {
                    //obstacle generator
                    Vector3 obstaclePos = new Vector3(15, 0, 0);
                    Instantiate(obstacle, obstaclePos, Quaternion.Euler(0, 0, 0));
                    block = false;
                    ranTime = ranRate;
                }
                //spider
                else if (random <= 90)
                {
                    //spider generator
                    Vector3 spiderPos = new Vector3(15, 3, 0);
                    Instantiate(spider, spiderPos, Quaternion.Euler(0, 0, 0));
                    block = false;
                    ranTime = ranRate;
                }
            }
            

            wTime--;
            if(wTime < 0)
            {
                Vector3 backGroundPos = new Vector3(40 , .5f, -3);
                Instantiate(background, backGroundPos, Quaternion.identity);

                wTime = wRate;
            }

            block = true;
            //ranRate *= .00001f;
           
        }

	}
}
