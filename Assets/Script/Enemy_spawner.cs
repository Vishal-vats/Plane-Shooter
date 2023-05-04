using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{

    public GameObject[] enemies;
    public float delayinenemyspawn = 3f;
    public int enemyspawnnumber = 10;
    public GameController gamecontroller;
    
    
    
    private bool allenemyspawned = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawn());
    }

    private void Update()
    {
        if(allenemyspawned && FindObjectOfType<Enemyshoot>()== null)
        {
            StartCoroutine(gamecontroller.levelcomplete());

            
            
           
        }
    }


    IEnumerator Enemyspawn()
    {
        for(int i = 0; i < enemyspawnnumber; i++)
        {
           yield return new WaitForSeconds(delayinenemyspawn);
           enemyspawn();
            
        }

        allenemyspawned = true;
        

    }


    void enemyspawn()
    {
        int randomenemy = Random.Range(0, enemies.Length);
        float randomenemyposition = Random.Range(-1.6f, 1.6f);
        Instantiate(enemies[randomenemy], new Vector2(randomenemyposition, transform.position.y), Quaternion.identity);
    }


}
