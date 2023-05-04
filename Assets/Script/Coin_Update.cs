using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Update : MonoBehaviour
{
    public Text score;
    int coin = 0;
    public Text finalscore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = coin.ToString();
        finalscore.text ="Coin: " + coin.ToString();
    }

    public void updatescore()
    {
        coin++;
    }
}
