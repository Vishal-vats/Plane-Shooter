using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pausepanel;
    public GameObject Pausebutton;
    public GameObject gameoverpanel;
    public GameObject finalscore;
    public AudioSource audiosource;
    public AudioSource resumeAudiosource;
    public AudioClip pausesound;
    public AudioClip resumesound;

    public GameObject levelcompletepanel;
    public GameObject wavecomplete;
    public AudioSource victorysound;
   
   //public AudioClip victorysound2;
   


    // Start is called before the first frame update
    void Start()
    {
        levelcompletepanel.SetActive(false);
        gameoverpanel.SetActive(false);
        pausepanel.SetActive(false);
        Pausebutton.SetActive(true);
        wavecomplete.SetActive(false);
    }

    // Update is called once per frame
  

    public void pausegame()
    {
        pausepanel.SetActive(true);
        Pausebutton.SetActive(false);
        AudioSource.PlayClipAtPoint(pausesound, Camera.main.transform.position);
        Time.timeScale = 0f;
        
    }

    public void resumegame()
    {
        pausepanel.SetActive(false);
        Pausebutton.SetActive(true);
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(resumesound, Camera.main.transform.position);
    }

   
    public void gameover()
    {
        gameoverpanel.SetActive(true);
        Pausebutton.SetActive(false);
    }

    public IEnumerator levelcomplete()
    {
        yield return new WaitForSeconds(2f);
        wavecomplete.SetActive(true);
        yield return new WaitForSeconds(3.2f);   
        victorysound.Play();
        levelcompletepanel.SetActive(true);
        Pausebutton.SetActive(false);
        finalscore.SetActive(false);
        Time.timeScale = 0f;
       
    }


    public void exitgame()
    {

        Application.Quit();

    }


}
