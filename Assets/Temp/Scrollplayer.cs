using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollplayer : MonoBehaviour
{
    public bool scroll = false;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool key = false;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Time.deltaTime * -speed, 0f, 0f);
            key = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Time.deltaTime * speed, 0f, 0f);
            key = true;
        }

        if(key==true && this.transform.position.x >= 0f)
        {
            scroll = true;
        }
        else
        {
            scroll = false;
        }

        float posx = Mathf.Clamp(this.transform.position.x, -8f, 0f);
        this.transform.position = new Vector2(posx, this.transform.position.y);
    }
}
