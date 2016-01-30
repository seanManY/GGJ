using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Instance Variables
    public GameObject floor;
    public GameObject player;
    public GameObject obstacle;

    private int random;

    public int rate = 10;
    private int time;

    public GameObject power;

	// Use this for initialization
	void Start () 
    {
        time = rate;

        //Vector3 powerPos = new Vector3(-5, 5, 0);
        //Instantiate(power, powerPos, Quaternion.identity);

        Vector3 playerPos = new Vector3(-5, 5, 0);
        Instantiate(player, playerPos, Quaternion.identity);

        for (int i = 0; i < 50; i++)
        {
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
            Vector3 floorPos = new Vector3(15, 0, 0);
            Instantiate(floor, floorPos, Quaternion.identity);
            time = rate;

            if(random > 5)
            {
                Vector3 obstaclePos = new Vector3(15, 0, 0);
                Instantiate(obstacle, obstaclePos, Quaternion.Euler(0, 0, 0));
            }
        }
	}
}
