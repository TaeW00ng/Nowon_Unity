using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Tile : MonoBehaviour
{
    public int stagenum = 1;
    public GameObject[] stage = new GameObject[10];
    GameObject playstage;
    public GameObject playerprefabs;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playstage = Instantiate(stage[stagenum - 1]);
        player = Instantiate(playerprefabs);
    }

    public void Stageclear()
    {
        stagenum++;
        Destroy(playstage);
        Destroy(player);
        playstage = Instantiate(stage[stagenum -1]);
        Invoke("Init_Stage", 0.2f);
    }

    void Init_Stage()
    {
        player = Instantiate(playerprefabs);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
