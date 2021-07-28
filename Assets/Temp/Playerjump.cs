using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerjump : MonoBehaviour
{

    public float speed;
    public float jump = 300f;
    public float distance = 0.7f;
    // Start is called before the first frame update
    Vector2 boxCastSize = new Vector2(0.4f, 0.05f);
    public GameObject dooropen;
    public GameObject doorclose;
    public GameObject key;

    void Start()
    {
        StageInit();
    }

    void StageInit()
    {
        dooropen = GameObject.Find("Dooropen");
        doorclose = GameObject.Find("Doorclose");
        key = GameObject.Find("Key");
        
        Debug.Log("=================init");
        key.SetActive(true);
        doorclose.SetActive(true);
        dooropen.SetActive(false);
        Debug.Log("============eee=====init");
        this.transform.position = GameObject.Find("Startpoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        bool onground = IsOnGround();

        if (Input.GetKeyDown(KeyCode.Space) && onground==true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump));
        }


        if(Input.GetKeyDown(KeyCode.DownArrow) && onground==true)
        {
            this.gameObject.layer = 7;
        }

        

    }

    private void FixedUpdate()
    {
        /*
        if (IsOnGround() == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump));
        }
        */
    }

    bool IsOnGround()
    {
        //RaycastHit2D raycasthit
        //   = Physics2D.Raycast(this.transform.position,
        //   Vector2.down, distance,LayerMask.GetMask("Floor"));

        RaycastHit2D raycasthit = Physics2D.BoxCast(
            this.transform.position, boxCastSize, 0f, Vector2.down, distance,
            LayerMask.GetMask("Floor"));

        //Debug.DrawRay(this.transform.position, Vector2.down * distance,Color.yellow);   

        if (raycasthit.collider != null)
        {
            if(raycasthit.collider.tag == "Ground")
            {
                return true;
            }
        }
        else
        {
            this.gameObject.layer = 6;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, Vector2.down * distance);
        Gizmos.DrawWireCube(this.transform.position + Vector3.down * distance, boxCastSize);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.name == "Key")
        {
            col.gameObject.SetActive(false);
            doorclose.SetActive(false);
            dooropen.SetActive(true);
        }

        Debug.Log("======>" + col.name);

        if(col.transform.tag=="Monster")
        {
            StageInit();
        }

        if (col.transform.name == "Dooropen")
        {
            GameObject.Find("GameManager").GetComponent<TileGameManager>().Stageclear();
        }
    }

}
