using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour
{

    // Instance Variables
    public GameObject Background;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject RedOut;
    public GameObject GreenOut;
    public GameObject BlueOut;
    public GameObject Heart;
    private GameObject[,] Powers = new GameObject[3,3];
    private GameObject[] Health = new GameObject[3];
    private Vector3 guiPos;

    // Use this for initialization
    void Start()
    {
        Instantiate(Background, new Vector3(-7.25f, 4, -1), Quaternion.identity);

        guiPos = new Vector3(-6.81f, 3, -2.5f);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (j)
                {
                    case 0:
                        Powers[i, j] = (GameObject)Instantiate(RedOut, guiPos + new Vector3(.75f * (float)i, -j, 0), Quaternion.identity);
                        break;
                    case 1:
                        Powers[i, j] = (GameObject)Instantiate(GreenOut, guiPos + new Vector3(.75f * (float)i, -j, 0), Quaternion.identity);
                        break;
                    case 2:
                        Powers[i, j] = (GameObject)Instantiate(BlueOut, guiPos + new Vector3(.75f * (float)i, -j, 0), Quaternion.identity);
                        break;
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            Health[i] = (GameObject)Instantiate(Heart, new Vector3(-7.45f + i, 7, -2), Quaternion.identity);
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
                Powers[x,y] = (GameObject)Instantiate(Red, guiPos + new Vector3(.75f * (float)x, -y, 0), Quaternion.identity);
                break;
            case 1:
                Powers[x,y] = (GameObject)Instantiate(Green, guiPos + new Vector3(.75f * (float)x, -y, 0), Quaternion.identity);
                break;
            case 2:
                Powers[x,y] = (GameObject)Instantiate(Blue, guiPos + new Vector3(.75f * (float)x, -y, 0), Quaternion.identity);
                break;
        }
    }

    public void damage(int health)
    {
        Destroy(Health[health]);
    }
}
