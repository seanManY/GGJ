using UnityEngine;
using System.Collections;

public class AirBehavior : MonoBehaviour {

    public int life = 300;

    public void Update()
    {
        life--;
        if (life <= 0)
            Destroy(this.gameObject);
    }
}
