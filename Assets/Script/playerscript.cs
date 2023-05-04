using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float speed = 10f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        boundaries();
    }

    void boundaries()
    {
        Camera screen = Camera.main;
        minX = screen.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxX = screen.ViewportToWorldPoint(new Vector3(1, 1, 0)).x - offset;
        minY = screen.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + offset;
        maxY = screen.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - offset;


    }



    // Update is called once per frame
    void Update()
    {

        //float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //float newposX = transform.position.x + moveX;
        //float newposY = transform.position.y + moveY;

        ////now we want to clamp the player within the screen

        //transform.position = new Vector2(Mathf.Clamp(newposX, minX, maxX), Mathf.Clamp(newposY, minY, maxY));


        if(Input.GetMouseButton(0))
        {
          Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, newPos, 10f * Time.deltaTime);
        }

        
    }





}
