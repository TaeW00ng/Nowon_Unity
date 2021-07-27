using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgscroll : MonoBehaviour
{
    public int type = 0;
    // Start is called before the first frame update
    public float speed = 2f;
    Vector2 startpos;
    public float endx;
    public float startx;
    public bool playerscroll;
    public float pluscount = 0f;



    void Start()
    {
        playerscroll = GameObject.Find("Player").GetComponent<Scroll_Player>().scroll;
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscroll == false)
        {
            return;
        }
        pluscount += 0.05f;

        if (type == 0)
        {
            float pos = Mathf.Repeat(Time.time * speed, 22f);
            this.transform.position = startpos + Vector2.left * pos;
        }
        else if(type == 1)
        {
            this.transform.Translate(Time.deltaTime * -speed, 0f, 0f);

            if (this.transform.position.x < endx)
            {
                this.transform.position = new Vector2(startx, this.transform.position.y);
            }
        }
        
        
    }
}
