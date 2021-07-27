using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Scroll : MonoBehaviour
{
    public bool scroll;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool key = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            key = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }

        if(key == true && this.transform.position.x >= 0f)
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
