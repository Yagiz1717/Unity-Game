using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishUIScript : MonoBehaviour
{
    public Button RestartButton;
    public Button QuitButton;
    public Text WinText;

    public FinishMusicScript FinishMusicScript;
    public WinnerControlScript WinnerControlScript;
    void Start()
    {
        FinishMusicScript = GameObject.FindGameObjectWithTag("FinishMusicTag").GetComponent<FinishMusicScript>();
        WinnerControlScript = GameObject.FindGameObjectWithTag("WinnerControlTag").GetComponent<WinnerControlScript>();
      
    }
    void Update()
    {
        
    }
    public void PlayerWin()
    {
        WinText.text = "WIN";
    }
    public void Bot_1Win()
    {
        WinText.text = "DEFEATED";
    }
    public void RestartGame()
    {   
        FinishMusicScript.StopMusic();
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void WinTextControl()
    {
            }
}







