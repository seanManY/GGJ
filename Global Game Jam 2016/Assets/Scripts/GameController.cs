using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject floor;
    public GameObject player;

	// Use this for initialization
	void Start () {

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
       
        Vector3 floorPos = new Vector3(15, 0, 0);
        Instantiate(floor, floorPos, Quaternion.identity);
       
	}
}
