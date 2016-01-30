using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour
{
    // Instance Variables
    public int speed;
    public int life;
    private int type;
    
    // Use this for initialization
    void Start()
    {

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
    void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "player")
            Destroy(this.gameObject);
    }

    public int Type()
    {
        return type;
    }

    public void SetType(int type)
    {
        this.type = type;
    }

    public void SetPosition(int posi)
    {
        transform.Translate(0, posi, 0);
    }
}
