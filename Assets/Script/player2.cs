using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2 : MonoBehaviour
{

    public float speed = 5;
    public GameObject Bullet;
    public Transform Firepoint;
    public float HP = 100f;
    public Image HP_Bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0f, 0f, Space.World);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0f, 0f, Space.World);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(Bullet, Firepoint);
            temp.transform.parent = null;

            if (this.transform.rotation.y != 0)
            {
                temp.GetComponent<Bullet>().speed = temp.GetComponent<Bullet>().speed * -1;
            }
            Destroy(temp, 5f);

        }

        float fillamount = (float)HP / 100f;
        HP_Bar.fillAmount = fillamount;

    }
}
