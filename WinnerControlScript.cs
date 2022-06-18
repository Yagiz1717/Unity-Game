using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerControlScript : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject Bot_1Object;

    public GameManager GameManager;
    public FinishMusicScript FinishMusicScript;
    public Animator PlayerAnimator;
    public Animator Bot_1Animator;
    public FinishUIScript FinishUIScript;

    //Variable
    public bool FPlayerWin;
    public bool FBot_1Win;

    void Start()
    {
        FPlayerWin = false;
        FBot_1Win = false;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {        
    }
    public void WinnerWait()
    {
        Invoke("Control", 1);        
    }    
    public void Control()
    {
        FinishMusicScript = GameObject.FindGameObjectWithTag("FinishMusicTag").GetComponent<FinishMusicScript>();
        FinishUIScript = GameObject.FindGameObjectWithTag("FinishUITag").GetComponent<FinishUIScript>();
        PlayerObject = GameObject.FindGameObjectWithTag("FinishPlayer");
        Bot_1Object = GameObject.FindGameObjectWithTag("FinishBot_1");             
        if (FBot_1Win)
        {
            PlayerObject.transform.position = new Vector3(0, -0.1f, 3);
            Bot_1Object.transform.position = new Vector3(0, 0.4f, 0);
            Bot_1Object.GetComponent<Animator>().SetBool("Bot_1Win", true);
            FinishUIScript.Bot_1Win();
        }
        if (FPlayerWin)
        {                       
            PlayerObject.transform.position = new Vector3(0,0.4f,0);
            Bot_1Object.transform.position = new Vector3(0, -0.1f, 3);
            PlayerObject.GetComponent<Animator>().SetBool("PlayerWin", true);
            FinishMusicScript.PlayMusic();
            FinishUIScript.PlayerWin();
        }        
    }
}
