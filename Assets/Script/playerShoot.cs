using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject playerbullet;
    public GameObject playerdamagevfx;

    public Transform gunpoint1;
    public Transform gunpoint2;

    public float bulletspawnTime;
    public playerhealth playerhealth1;
    public GameObject muzzelflash;
    public Coin_Update coincounting;
    public GameController gamecontroller;

    public AudioSource playershootsound;
    public AudioClip impactsound;
    public AudioClip explosionsound;
    public AudioClip coincollectionsound;
    public AudioClip planedeathhumansound;

   


    public float health = 10f;
    float barsize = 1f;
    float damage = 0;


    public GameObject playerexplosion;


    // Start is called before the first frame update
    void Start()
    {
        muzzelflash.SetActive(false);
        
        StartCoroutine(continuousshoot());
        
        damage = barsize / health;
    }

    // Update is called once per frame

    private void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemybullet")
        {
            Destroy(collision.gameObject);
            setplayerhealth();
            playershootsound.PlayOneShot(impactsound, 0.8f);
            GameObject damagevfx = Instantiate(playerdamagevfx, collision.transform.position, Quaternion.identity);

            Destroy(damagevfx, 0.05f);

            if(health <=0 )
            {
                AudioSource.PlayClipAtPoint(planedeathhumansound, Camera.main.transform.position,2f);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(explosionsound, Camera.main.transform.position,0.5f);
                GameObject playerblast = Instantiate(playerexplosion, transform.position, Quaternion.identity);
                Destroy(playerblast, 2f);
                gamecontroller.gameover();
            }
         
         
           

        }

        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coincounting.updatescore();
            playershootsound.PlayOneShot(coincollectionsound, 0.5f);

        }


    }


    void setplayerhealth()
    {
        if(health > 0)
        {
            health -= 1;
            barsize = barsize - damage;
            playerhealth1.sethealth(barsize);
        }    
    }




    void spawnbullets()
    {
        

            Instantiate(playerbullet, gunpoint1.position, Quaternion.identity);
            Instantiate(playerbullet, gunpoint2.position, Quaternion.identity);
        



    }

    //for delay in execution WE use Coroutine method

    IEnumerator continuousshoot()
    {

      

        while (true)
        {
            yield return new WaitForSeconds(bulletspawnTime);
            spawnbullets();
            
            playershootsound.Play();
            muzzelflash.SetActive(true);
            yield return new WaitForSeconds(0.06f);
            muzzelflash.SetActive(false);


        }



    }

       
   




}
