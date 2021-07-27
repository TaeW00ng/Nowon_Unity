using UnityEngine;

public class bgscroll : MonoBehaviour
{
    public int type = 0;
    // Start is called before the first frame update
    public float speed = 2f;
    Vector2 startpos;
    public float endx;
    public float startx;
    GameObject player;
    bool playerscroll;
    float pluscount = 0f;

    void Start()
    {
        player = GameObject.Find("Player");
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerscroll = player.GetComponent<Scrollplayer>().scroll;
        if(playerscroll == false)
        {
            return;
        }

        pluscount += 0.05f;

        if (type==0)
        {
            float pos = Mathf.Repeat(pluscount * speed, 17.8f);
            this.transform.position = startpos + Vector2.left * pos;
        }


        else if(type==1)
        {
            this.transform.Translate(Time.deltaTime * -speed, 0f, 0f);

            if(this.transform.position.x <=endx)
            {
                this.transform.position = new Vector2(startx, this.transform.position.y);
            }
        }
        

    }
}
