using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    int currentindex;
    
    // Start is called before the first frame update
    void Start()
    {
        currentindex = SceneManager.GetActiveScene().buildIndex;

    }

   public void nextLevel()
    {
        SceneManager.LoadScene(currentindex + 1);
        Time.timeScale = 1f;
    }
 
    public void restartgame()
    {
        SceneManager.LoadScene(currentindex);
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}
