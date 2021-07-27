using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float Speed;
    public Transform Tf;
    public Transform[] MoveTf = new Transform[4];
    int count = 0;
    public bool Chase = false;
    public float Playtime = 0;
    public bool stop = false;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Chase = false;
    }

    // Update is called once per frame
    void Update()
    {
        string aniname = "Ghost_Idle";

        if(stop == true)
        {
            return;
        }

        int prevtime = (int)Playtime;

        Playtime += Time.deltaTime;

         if((int)Playtime %5==0   && prevtime != (int)Playtime)
        {
            Speed += 0.1f;
        }

        float dis = Vector3.Distance(this.transform.position, MoveTf[0].position);

        /* if(dis > 5f && Chase == false)
        {
            return;
        }
        else
        {
            Chase = true;
        } */

         if(dis <= 5f)
        {
            Chase = true;
            
        }
        if (Chase == true)
        {
            Vector3 pos = Vector3.MoveTowards(this.transform.position, MoveTf[count % MoveTf.Length].position, Speed * Time.deltaTime);
            this.transform.position = pos;
            aniname = "Ghost_Move";
        }

        this.GetComponent<Animator>().Play(aniname);


        // Vector3 velo = Vector3.zero;

        // Vector3 pos = Vector3.MoveTowards(this.transform.position, MoveTf[count%MoveTf.Length].position, Speed * Time.deltaTime);

        // Vector3 pos = Vector3.MoveTowards(this.transform.position, Tf.position , Speed * Time.deltaTime);
        // Vector3 pos = Vector3.Lerp(this.transform.position, Tf.position, 0.4f * Time.deltaTime);
        // Vector3 pos = Vector3.SmoothDamp(this.transform.position, Tf.position, ref velo, 0.05f);
        // Vector3 pos = Vector3.Slerp(this.transform.position, Tf.position, 0.4f * Time.deltaTime);
        // this.transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            count++;
        }
    }

}
