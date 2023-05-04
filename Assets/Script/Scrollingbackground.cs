using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollingbackground : MonoBehaviour
{
    public Renderer meshrenderer;
    public float speed = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshrenderer.material.mainTextureOffset += new Vector2(0,  speed * Time.deltaTime);
    }
}
