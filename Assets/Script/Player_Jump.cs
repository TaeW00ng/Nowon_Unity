using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{

    public float Speed = 0;
    public float Jump = 0;
    public float Distance = 0.7f;
    Vector2 boxCastSize = new Vector2(0.4f, 0.05f);
    //public bool AutoJump = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-Speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           this.transform.Translate(Speed * Time.deltaTime, 0f, 0f);

        }


        bool onground = IsOnGround();

        

        if(onground==true && this.gameObject.layer == 7 && this.GetComponent<Rigidbody2D>().velocity.y==0f)
        {
            this.gameObject.layer = 7;
        }
       
        if(Input.GetKeyDown(KeyCode.DownArrow)&& onground == true)
        {
            this.gameObject.layer = 8;
        }

        IsOnGround();
    }

    private void FixedUpdate()
    {
        if (IsOnGround() == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jump));
        }
    }

    bool IsOnGround()
    {

        // RaycastHit2D raycasthit = Physics2D.Raycast(this.transform.position, Vector2.down, Distance, LayerMask.GetMask("Floor"));
        RaycastHit2D raycasthit = Physics2D.BoxCast(this.transform.position, boxCastSize, 0f, Vector2.down, Distance, LayerMask.GetMask("Floor"));

        // Debug.DrawRay(this.transform.position, Vector2.down * Distance, Color.yellow);

        if (raycasthit.collider != null)
        {
            // Debug.Log(raycasthit.collider.name);
            if(raycasthit.collider.tag == "Ground")
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(this.transform.position, Vector2.down * Distance);
        Gizmos.DrawWireCube(this.transform.position + Vector3.down * Distance, boxCastSize);
    }

}
