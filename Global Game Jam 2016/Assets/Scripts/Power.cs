using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour
{
    // Instance Variables
    public int speed;
    public int life;
    private int type;
    private int posi;

    // Use this for initialization
    void Start(int type, int posi)
    {
        this.type = type;
        transform.Translate(0, posi, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * -speed, 0, 0);

        life--;
        if(life <= 0)
            Destroy(this.gameObject);
    }
    
    // Methods
    void OnCollisionEnter(Collider obj)
    {
        if(obj.tag == "player")
            Destroy(this.gameObject);
    }

    public int Type()
    {
        return type;
    }
}
