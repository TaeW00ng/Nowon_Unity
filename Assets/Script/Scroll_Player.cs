using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Player : MonoBehaviour
{
    public bool scroll = false;
    public float speed = 10f;
    public bool key;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }

        if (key == true && transform.position.x >= 0f)
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
