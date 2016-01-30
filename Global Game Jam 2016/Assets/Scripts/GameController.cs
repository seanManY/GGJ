using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Instance Variables
    public GameObject floor;
    public GameObject player;
<<<<<<< HEAD
    public int rate = 10;
    private int time;

	// Use this for initialization
	void Start ()
    {
        time = rate;
        
=======
    public GameObject power;

	// Use this for initialization
	void Start () 
    {
        Vector3 powerPos = new Vector3(-5, 5, 0);
        Instantiate(power, powerPos, Quaternion.identity);

>>>>>>> origin/master
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
        time--;
        if (time < 0)
        {
            Vector3 floorPos = new Vector3(15, 0, 0);
            Instantiate(floor, floorPos, Quaternion.identity);
            time = rate;
        }
	}
}
