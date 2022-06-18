using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{

    public AudioSource AudioSource;

    public GameObject MainObject;
    void Start()
    {
        AudioSource.Play();
    }

    
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        MainObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
