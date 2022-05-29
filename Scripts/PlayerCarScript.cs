using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarScript : MonoBehaviour
{

    

    string[] _carTags = {"GreenCarTag" ,"RedCarTag" , "PoliceCarTag" ,"BlueCarTag" };

    private bool _carStop;
    void Start()
    {
        _carStop = false;
    }

    void Update()
    {
        if (!_carStop)
        {
            CarMovement();
        }
       

        TouchControl();
    }
    public void TouchControl()
    {
        if (Input.touchCount > 0)
        {
            CarOvertaking();            
        }
        else if (Input.touchCount == 0)
        {
            if (transform.position.x < 1.5f)
            {
                CarOvertakingBack();
            }
        }
    }
    public void CarMovement()
    {
        transform.Translate(new Vector3(0, 0, 6) * Time.deltaTime*5);
    }
    public void CarMovementSpeedy()
    {
        transform.Translate(new Vector3(0, 0, 6) * Time.deltaTime*4);
    }
    public void CarMovementStop()
    {
        transform.Translate(new Vector3(0, 0, 6) * Time.deltaTime*2);
    }
    public void CarOvertaking()
    {
        if (transform.position.x > -1.5f)
        {
            transform.Translate(new Vector3(-1.5f, 0, 0) * Time.deltaTime * 5);            
        }
        if(transform.position.x < -0.5f)
        {
            CarMovementSpeedy();
        }    
    }
    
    public void CarOvertakingBack()
    {   
        transform.Translate(new Vector3(1.5f, 0, 0) * Time.deltaTime * 5);
         
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        for (int i = 0; i < _carTags.Length; i++)
        {
            if (collision.gameObject.tag == _carTags[i])
            {
                
                
            }
        }            
    }
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < _carTags.Length; i++)
        {
            if (other.gameObject.tag == _carTags[i])
            {
                _carStop = true;
                CarMovementStop();
               
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _carTags.Length; i++)
        {
            if (other.gameObject.tag == _carTags[i])
            {
                _carStop = false;
            }
        }
    }












}
