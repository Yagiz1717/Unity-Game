using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCarScript : MonoBehaviour
{

    private bool _leftControl;
    private float _velocity;

    void Start()
    {        
        if (transform.position.z <0)
        {
            _leftControl = true;            
        }
        else
        {
            _leftControl = false;
        }
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (_leftControl)
        {
            transform.Translate(new Vector3(0,0,-6)*Time.deltaTime*2);
        }
        else
        {
            transform.Translate(new Vector3(6, 0,0 )*Time.deltaTime*2);
        }        
    }    
}
