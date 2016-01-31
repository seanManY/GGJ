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
    public GameObject Highlighter;
    public GameObject Heart;
    private GameObject[,] Powers = new GameObject[3,3];
    private GameObject[] Health = new GameObject[3];
    private GameObject select;
    private Vector3 guiPos;
    private Vector3 highPos;

    // Use this for initialization
    void Start()
    {
        Instantiate(Background, new Vector3(-7.25f, 4, -1), Quaternion.identity);

        guiPos = new Vector3(-6.81f, 2.8f, -2.5f);
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

        highPos = new Vector3(-6.85f, 2.63f, -1.5f);
        select = (GameObject)Instantiate(Highlighter, highPos, Quaternion.identity);

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

    public void empty(int type)
    {
        GameObject t = null;
        switch (type)
        {
            case 0:
                t = RedOut;
                break;
            case 1:
                t = GreenOut;
                break;
            case 2:
                t = BlueOut;
                break;
        }

        for(int i = 0; i < 3; i++)
        {
            Destroy(Powers[i, type]);
            Powers[i,type] = (GameObject)Instantiate(t, guiPos + new Vector3(.75f * (float)i, -type, 0), Quaternion.identity);
        }
    }

    public void damage(int health)
    {
        Destroy(Health[health]);
    }



    internal static void Label(Rect rect, string p)
    {
        throw new System.NotImplementedException();
    }


    public void heal()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(Health[i]);
            Health[i] = (GameObject)Instantiate(Heart, new Vector3(-7.45f + i, 7, -2), Quaternion.identity);
        }
    }

    public void scroll(int pow)
    {
        select.transform.position = highPos + (new Vector3(0, -1.14f, 0)) * pow;

    }
}
