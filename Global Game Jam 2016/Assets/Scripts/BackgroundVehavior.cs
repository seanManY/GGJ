using UnityEngine;
using System.Collections;

public class BackgroundVehavior : MonoBehaviour {

    public int speed = 5;
    public int life = 100;

 

    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * -speed, 0, 0);

        life--;
        if (life <= 0)
            Destroy(this.gameObject);
    }
}
