using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{
    public GameObject Monster;
    public GameObject Background;
    public Transform[] point = new Transform[5];
    public int score = 0;
    public Text scoretext;
    public GameObject Panel;
    public int Goal_Socre = 30;
    
    



    // Start is called before the first frame update
    void Start()
    {
        int[] check = new int[5];
        int makecount = 0;
        while (true)
        {
            int temp = Random.RandomRange(0, 5);
            
            if (check[temp] == 0)
            {
                GameObject mon = Instantiate(Monster, point[temp]);
                GameObject monparnt = GameObject.Find("Monster");
                mon.transform.parent = monparnt.transform;
                mon.transform.name = "Monster";
                check[temp] = 1;
                makecount++;

                if (makecount == 3)
                {
                    break;
                }
            }

            Panel.SetActive(false);


        }

        Instantiate(Background);
        //GameObject mon = Instantiate(Monster);
        //mon.transform.position = new Vector2(-6.8f, 3.1f);

        //Instantiate(monster, new Vector3(-6.8f, 3.1f, 0f), Quaternion.identity);
        
        /* for(int i = 0; i < 3; i++)
        {
            int Rand = Random.RandomRange(0, point.Length);
            GameObject mon = Instantiate(Monster, point[Rand]);
            GameObject monparnt = GameObject.Find("Monster");
            mon.transform.parent = monparnt.transform;
            mon.transform.name = "Monster";
            
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "SCORE : " + score;

        if (GameObject.FindGameObjectWithTag("Monster") == null)
        {
            Panel.SetActive(true);
        }

        /* if(Goal_Socre == score)
        {
            Panel.SetActive(true);
        } */

        

    }
    

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score += value;
        }
    }

}
