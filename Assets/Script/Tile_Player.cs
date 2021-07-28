using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Player : MonoBehaviour
{

    public float speed = 10f;
    public float jump = 300f;
    public float distance = 0.7f;
    // Start is called before the first frame update
    Vector2 boxCastSize = new Vector2(0.4f, 0.05f);
    public GameObject door_open;
    public GameObject door_close;
    public GameObject Spawn_Player;
    public GameObject Key;

    void Start()
    {
        door_open = GameObject.Find("Door_open");
        door_close = GameObject.Find("Door_close");
        Key = GameObject.Find("Key");
        StageInit();
    }

    void StageInit()
    {
        
        door_close.SetActive(true);
        door_open.SetActive(false);
        Key.SetActive(true);

        Spawn_Player = GameObject.Find("Spawn_Player");
        this.transform.position = Spawn_Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        bool onground = IsOnGround();

        if (Input.GetKeyDown(KeyCode.Space) && onground == true)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump));
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && onground == true)
        {
            this.gameObject.layer = 7;
        }



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
            if (raycasthit.collider.tag == "Ground")
            {
                return true;
            }
        }
        else
        {
            this.gameObject.layer = 7;
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
            door_close.SetActive(false);
            door_open.SetActive(true);
        }

        if(col.transform.tag == "Enemy")
        {
            StageInit();
        }
        if (col.transform.name == "Door_open")
        {
            GameObject.Find("GameManager").GetComponent<GameManager_Tile>().Stageclear();
            
        }
    }

}
