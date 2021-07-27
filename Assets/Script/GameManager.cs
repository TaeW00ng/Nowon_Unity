using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Key;
    // public bool Show = false;
    public float Playtime = 0;
    public GameObject Door;
    public GameObject Player;
    public bool Getkey = false;

    // Start is called before the first frame update
    void Start()
    {
        // Show = false;
        Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Getkey == true)
        {
            return;
        }

        Playtime += Time.deltaTime;

        if(Playtime > 5f && Key.activeSelf == false)
        {
            Key.SetActive(true);
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-2f, 2f);
            Key.transform.position = new Vector3(x, y, 0f);
        }
        if (Playtime > 7f)
        {
            Key.SetActive(false);
            Playtime = 0;
        }


        /* if (Show == false && Key.activeSelf == false)
        {
            Key.SetActive(false);
        }
        else
        {
            Key.SetActive(true);
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-2f, 2f);
            Key.transform.position = new Vector3(x, y, 0f);
        }
        Playtime += Time.deltaTime;
        if(Playtime >= 5f)
        {
            Show = true;
        } */
    }

}
