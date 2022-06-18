using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{

    public GameManager GameManagerScript;

    void Start()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (GameManagerScript.PlayerObject.transform.position.x > transform.position.x + 40)
        {
            Destroy();
        }

    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
