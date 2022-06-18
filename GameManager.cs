using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //GameObject
    public GameObject CubeObject;
    public GameObject StartingCube;
    public GameObject Floor;
           GameObject a;
           GameObject b;
           Component  c;
    public GameObject TextObject;
    public GameObject PlayerObject;
    public Text ScoreTextUI;    
    TouchScreenKeyboard _keybord;
    public InputField InputField;
    public GameObject InputFieldObject;
    public GameObject RestartButton;
    public GameObject ContinueButton;
    public GameObject QuitButton;
    
    public GameObject FinishScreen;
    public GameObject Bot_1Object;
    public GameObject WinnerControlObject;
    public Text FirstText;
    public Text SecondText;
    public Text ThirdText;

    //Script
    public TextScript TextScript;
    public Animator AnimatorController;
    public Animator BotAnimatorController;
    public MainCameraScript MainCameraScript;
    public GameMusic GameMusic;
    public WinnerControlScript WinnerControlScript;
    
    //Variable          
    //Integer
    
    public int GetLeftx;
    public int BotGetLeftx;
    public float BotGetLefTime;
    public int t;
           int i;    
           int Textx = -3;
    public int CubeNumber;
    public int  Score;
   
    float time=40f;
    int BotStartTime;
    public int cubeControlNumber;

    //String
    string text="I made this game very nice";
    public string[] Winner = new string[2];

    //Bool
    public bool left;
    public bool Botleft;
    
    void Start()
    {
       
        
        WinnerControlScript.FBot_1Win = false;
        WinnerControlScript.FPlayerWin = false;
        cubeControlNumber = 0;
        StartCoroutine(BotWaitTime());
        InputFieldObject.SetActive(true);
        left = false;
        Botleft = false;
        TextSpawn();       
        _keybord = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
               
    }
    void Update()
    {
        
        BotMovement();
        if (t<text.Length)
        {
            TextControl();
        }
        else if (t == 26 && PlayerObject.transform.position.x > GetLeftx - 7)
        {
            Debug.Log("Player kazandý.");
            WinnerControlScript.FPlayerWin = true;
            WinnerControlScript.FBot_1Win = false;
            WinnerControlScript.WinnerWait();
            SceneManager.LoadScene(2);
        }

        if (left)
        {
            AnimatorController.SetBool("running", true);
            PlayerObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime *20);
            MainCameraScript.transform.position = PlayerObject.transform.position+new Vector3(-10,47,-75);
            Floor.transform.position = PlayerObject.transform.position + new Vector3(0,-10,0);
        }
        if (PlayerObject.transform.position.x>GetLeftx-7)
        {
            AnimatorController.SetBool("running", false);
            left = false;          
        }
        WinnerControl();
        if (Bot_1Object.transform.position.x>PlayerObject.transform.position.x)
        {
            FirstText.text = "Bot_1";
            SecondText.text = "Player";
        }
        if (Bot_1Object.transform.position.x < PlayerObject.transform.position.x)
        {
            FirstText.text = "Player";
            SecondText.text = "Bot_1";
        }
    }   
    public void CubeSpawn()
    {          
        b = Instantiate(CubeObject, new Vector3(0, 0, 0), Quaternion.identity);
        b.transform.position = new Vector3(GetLeftx,0,0);
        GetLeftx += 7;
        left = true;
        CubeNumber++;
    }
    //public void SpaceTextSpawn()
    //{
    //    a = Instantiate(TextObject, new Vector3(Textx, 3, 5.6f), Quaternion.Euler(90, 0, 0)) as GameObject;        
    //    a.GetComponent<TextMesh>().text = " ";
    //    Textx += 7;
    //    CubeSpawn();
    //}
    //public void TextCreater()
    //{
    //    text = words[Random.Range(0, words.Length)];
    //}
    public void TextSpawn()
    {
        //TextCreater();
        for (i = 0; i < text.Length; i++)
        {
            a = Instantiate(TextObject, new Vector3(Textx, 3, 5.6f), Quaternion.Euler(90, 0, 0));
            a.GetComponent<TextMesh>().text = text[i].ToString();
            Textx += 7;
        }
    }
    public void WinnerControl()
    {       
    }    
    public void TextControl()
    {
        if (text[t].ToString() == InputField.text.ToString())
        {
            InputField.text = "";
            CubeSpawn();
            Score++;
            t++;
        }
        else if (text[t].ToString() != InputField.text.ToString())
        {
            InputField.text = "";
        }        
    }
    public void PauseGame()
    {
        ContinueButton.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
        GameMusic.StopMusic();
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        ContinueButton.SetActive(false);
        RestartButton.SetActive(false);
        QuitButton.SetActive(false);
        GameMusic.PlayMusic();
    }
    public void RestartGame()
    {       
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        InputFieldObject.SetActive(true);
        //ContinueButton.SetActive(false);
        //RestartButton.SetActive(false);
        //QuitButton.SetActive(false);
        //FinishScreen.SetActive(false);
        GameMusic.PlayMusic();
        time = 20;
        Score = 0;
        t = 0;
        Textx = -3;
        GetLeftx = 0;
        TextSpawn();
        BotStartTime = 0;       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void FinishScreenGame()
    {
        //FinishScreen.SetActive(true); 
        //InputFieldObject.SetActive(false);
        //RestartButton.SetActive(true);
        //QuitButton.SetActive(true);
        //GameMusic.StopMusic();
    
    }    
    //Bot Methods    
    public void BotMovement()
    {        
        if (Botleft)
        {
            BotAnimatorController.SetBool("running", true);
            Bot_1Object.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 20);
        }
        if (Bot_1Object.transform.position.x > BotGetLeftx - 7)
        {
            BotAnimatorController.SetBool("running", false);
            Botleft = false;
            
        }
    }
    public void BotGetLeftxUpdate()
    {
        BotCubeSpawn();        
        Botleft = true;
        
    }
    public void BotCubeSpawn()
    {
        if (cubeControlNumber<26)
        {
            cubeControlNumber++;
            Instantiate(CubeObject, new Vector3(BotGetLeftx, 0, 15), Quaternion.identity);
            
            BotGetLeftx += 7;
        }        
        if (cubeControlNumber==26 && Bot_1Object.transform.position.x>BotGetLeftx-7)
        {
            Debug.Log("Bot kazandý.");
            WinnerControlScript.WinnerWait();
            SceneManager.LoadScene(2);
            Debug.Log("Oyun bitti.");
            WinnerControlScript.FBot_1Win = true;
            WinnerControlScript.FPlayerWin = false;
        }
        
    }    
    IEnumerator BotWaitTime()
    {        
        BotGetLefTime = Random.Range(0,3.5f);
        yield return new WaitForSeconds(BotGetLefTime);
        BotGetLeftxUpdate();
        Deneme();
    }
    public void Deneme()
    {
        StartCoroutine(BotWaitTime());
    }
}
