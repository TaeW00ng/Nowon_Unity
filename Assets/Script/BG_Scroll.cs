using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    public int type = 0;
    // Start is called before the first frame update
    public float speed = 2f;
    Vector2 startpos;
    public float endx;
    public float startx;
    GameObject player;
    bool playscroll;
    float pluscount = 0f;

    void Start()
    {
        startpos = this.transform.position;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playscroll = player.GetComponent<Player_Scroll>().scroll;
        if (playscroll == false)
        {
            return;
        }

        pluscount += 0.05f;

        if (type == 0)
        {
            float pos = Mathf.Repeat(pluscount * speed, 17.8f);
            this.transform.position = startpos + Vector2.left * pos;
        }
        

        else if(type == 1)
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f);

            if(this.transform.position.x <= endx)
            {
                this.transform.position = new Vector2(startx, this.transform.position.y);
            }
        }

        
    }
}
