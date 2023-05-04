using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

   public void health(float damage)
    {
        bar.localScale = new Vector2(damage, 1f); 
    }
   
}
