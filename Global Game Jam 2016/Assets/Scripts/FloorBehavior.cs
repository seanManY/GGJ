using UnityEngine;
using System.Collections;

public class FloorBehavior : MonoBehaviour {

    public int speed = 5;
    public int life  = 100;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * -speed, 0, 0);

        life--;
        if (life <= 0)
            Destroy(this.gameObject);
	}
}
