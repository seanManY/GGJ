using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour
{

    // Instance Variables
    public GameObject Outline;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Heart;
    private GameObject[,] Powers = new GameObject[3,3];
    private GameObject[] Health = new GameObject[3];
    private Vector3 guiPos;

    // Use this for initialization
    void Start()
    {
        guiPos = new Vector3(-11, 8, -1);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Powers[i,j] = (GameObject)Instantiate(Outline, guiPos + new Vector3(2*i, -j, 0), Quaternion.identity);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            Health[i] = (GameObject)Instantiate(Heart, new Vector3(8 + 2*i, 8, 0), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update()
    {
	    
	}

    public void add(int x, int y)
    {
        Destroy(Powers[x,y]);
        switch(y)
        {
            case 0:
                Powers[x,y] = (GameObject)Instantiate(Red, guiPos + new Vector3(2 * x, -y, 0), Quaternion.identity);
                break;
            case 1:
                Powers[x,y] = (GameObject)Instantiate(Green, guiPos + new Vector3(2 * x, -y, 0), Quaternion.identity);
                break;
            case 2:
                Powers[x,y] = (GameObject)Instantiate(Blue, guiPos + new Vector3(2 * x, -y, 0), Quaternion.identity);
                break;
        }
    }

    public void damage(int health)
    {
        Destroy(Health[health]);
    }
}
