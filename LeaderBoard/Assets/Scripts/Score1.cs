using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public GameObject sccore;
    static int highscore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sccore.GetComponent<Text>().text = Game.ScrDestroyOnCol.count.ToString();

    }
}
