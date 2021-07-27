using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 1;
    public GameObject Door;


    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        string aniname = "Player_Idle";

        if (Input.GetKey(KeyCode.UpArrow))
        {
            aniname = "Player_Walk_Up";
            this.transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            aniname = "Player_Walk_Down";
            this.transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aniname = "Player_Walk_Left";
            this.transform.Translate(-speed * Time.deltaTime,0f,0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            aniname = "Player_Walk_Right";
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        this.GetComponent<Animator>().Play(aniname);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Key")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Getkey = true;
            collision.gameObject.SetActive(false);
            Door.SetActive(true);

            GameObject.Find("Ghost").GetComponent<Ghost>().stop = true;

        }
    }

}
