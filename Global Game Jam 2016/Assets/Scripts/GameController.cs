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

    private GameObject POWER;
    public  GameObject power;

	// Use this for initialization
	void Start () 
    {
        time = rate;

        

        //player
        Vector3 playerPos = new Vector3(-5, 5, 0);
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
        random = Random.Range(0, 10);
        time--;
        if (time < 0)
        {
            //floor generator
            Vector3 floorPos = new Vector3(15, 0, 0);
            Instantiate(floor, floorPos, Quaternion.identity);
            time = rate;

            if(random > 5)
            {
                //obstacle generator
                //Vector3 obstaclePos = new Vector3(15, 0, 0);
                //Instantiate(obstacle, obstaclePos, Quaternion.Euler(0, 0, 0));

                //spider generator
                //Vector3 spiderPos = new Vector3(15, 7, 0);
                //Instantiate(spider, spiderPos, Quaternion.Euler(0, 0, 0));

                //power ups
                int powRandHeight = Random.Range(2, maxRange);
                Vector3 powerPos = new Vector3(15, powRandHeight, 0);
                POWER = (GameObject)Instantiate(power, powerPos, Quaternion.identity);
                int powRandom = Random.Range(0, 3);
                POWER.GetComponent<Power>().setTag(powRandom);
                
                
            }
           
        }
	}
}
