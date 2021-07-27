using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Hitcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Hitcount++;
            Destroy(collision.gameObject);
            if (Hitcount == 3)
            {
                // plus score
                GameObject.Find("StageManager").GetComponent<StageManager>().Score = 10;

                Destroy(this.gameObject);
            }
        }
    }

}
