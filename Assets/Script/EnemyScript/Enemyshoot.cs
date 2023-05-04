using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public GameObject enemybullet;
    public GameObject damageeffect;
   
    public Transform[] gunpoint;

    public float bulletspawn;
    public GameObject muzzelflash;

    public GameObject explosion;
    public healthbar healthbar1;
    public GameObject coinprefab;

    public AudioSource audiosource;
    public AudioClip explosionsound;
   

    public float health = 10f;
    float barsize =  1f ;
    float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        muzzelflash.SetActive(false)
;       StartCoroutine(shoot());
        damage = barsize / health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "playerBullet")
        {
            Destroy(collision.gameObject);
            sethealthvalue();
            GameObject damagevfx = Instantiate(damageeffect, collision.transform.position, Quaternion.identity);
            Destroy(damagevfx, 0.05f);

            if(health <= 0)
            {
                Destroy(gameObject);

                AudioSource.PlayClipAtPoint(explosionsound, Camera.main.transform.position, 1f);

                Instantiate(coinprefab, transform.position, Quaternion.identity);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 0.55f);

            }
            
        }

        

    }

    void sethealthvalue()
    {
        if(health>0)
        {
            health -= 1;
            barsize = barsize - damage;
            healthbar1.health(barsize);
        }

    }
    



    void enemyshoot()
    {
       for(int i =0; i< gunpoint.Length; i++)
        {
            
            Instantiate(enemybullet, gunpoint[i].position, Quaternion.identity);
            //Instantiate(enemybullet, gunpoint2.position, Quaternion.identity);

        }
    }

    IEnumerator shoot()
    {
        while(true)
        {

            yield return new WaitForSeconds(bulletspawn);
            enemyshoot();
            audiosource.Play();
            muzzelflash.SetActive(true);

            yield return new WaitForSeconds(0.06f);
            muzzelflash.SetActive(false);

        }
    }

}
