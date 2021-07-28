using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Ghost : MonoBehaviour
{
    float mx;
    Vector3 startpos;
    
    // Start is called before the first frame update
    void Start()
    {
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Mathf.Cos(Time.time * 5f);
        this.transform.position = new Vector3(startpos.x + (mx * 2f), startpos.y);
    }
}
