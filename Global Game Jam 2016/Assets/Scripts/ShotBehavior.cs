using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public int speed = 5;
    public int life = 600;

  
    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * -speed, 0, 0);

        life--;
        if (life <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider coll)
    {
        
        if(coll.gameObject.tag == "Web")
        {
            Debug.Log(coll);

            Destroy(coll.transform.parent.gameObject);
            Destroy(this.gameObject);
        }

        if(coll.gameObject.tag == "Spider")
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);

           
        }
    }
}
