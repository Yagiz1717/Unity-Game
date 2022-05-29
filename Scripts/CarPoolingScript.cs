using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPoolingScript : MonoBehaviour
{
    private Queue<GameObject> _carPooling;
    private Queue<GameObject> _rightCarPooling;
    private Queue<GameObject> _leftCarPooling;


    [SerializeField] private GameObject _carObjectOne;
    [SerializeField] private GameObject _carObjectTwo;
    [SerializeField] private GameObject _carObjectThree;
    [SerializeField] private GameObject _carObjectFour;

    [SerializeField] private GameObject _playerCarObject;

    [SerializeField] private  PoolingScript _poolingScript;
    
    

    private int _poolSize = 60;
    private int _randomWaitTime;
    private int _randomCarSelectNumber;
    private int _leftCarSpawnPositionz;
    private int _rightCarSpawnPositionz;
    int _randomCarSpawnPositionz;
    public  int _randomCarDistance;

    int _leftCarDistance;
    int _rightCarDistance;

    public int _rightz;
    public int _leftz;

    private bool _leftSpawn;
    private bool _rightSpawn;

    GameObject RightObject;
    GameObject LeftObject;
    
    void Start()
    {
        StartRightCarSpawn();
        StartLeftCarSpawn();
        _rightz = 40;
        _leftSpawn = false;
        _rightSpawn = false;

        _randomCarSpawnPositionz = 30;

        _randomCarDistance += Random.Range(10, 20);
        _leftCarDistance += Random.Range(10, 20);
                
        StartCoroutine(nameof(LShortTimeSpawn));
        StartCoroutine(nameof(LNormalTimeSpawn));

    }
    private void Awake() //Random Car Pool
    {        
        _leftCarPooling = new Queue<GameObject>();
        _rightCarPooling = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject _carObject;

            _randomCarSelectNumber = Random.Range(1, 100);

            if (_randomCarSelectNumber < 25)
            {
                _carObject = Instantiate(_carObjectOne);
            }
            else if (_randomCarSelectNumber < 50)
            {
                _carObject = Instantiate(_carObjectTwo);
            }
            else if (_randomCarSelectNumber < 75)
            {
                _carObject = Instantiate(_carObjectThree);
            }
            else
            {
                _carObject = Instantiate(_carObjectFour);
            }
            _carObject.SetActive(false);
            
            int _randomNumber = Random.Range(1,3);//Right Left Random Calculator
            if (_randomNumber == 1)
            {                
                _leftCarPooling.Enqueue(_carObject);
            }
            if (_randomNumber == 2)
            {                
                _rightCarPooling.Enqueue(_carObject);
            }
        }        
    }   
    private void Update()
    {
        RightCarSpawnControl();
        LeftCarSpawnControl();
    }    
    private void RightCarSpawnControl()
    {        
        if (_poolingScript._roadPositionz-10 > RightObject.transform.position.z + _rightz)
        {
            _rightz = Random.Range(40, 55);
            RightCarSpawn();
        }        
    }
    private void StartRightCarSpawn()
    {
        GameObject _rightCarObject = _rightCarPooling.Dequeue();
        RightObject = _rightCarObject;
        _rightCarObject.SetActive(true);
        _rightCarObject.transform.position = new Vector3(1.5f, 0.89f, 30);
        _rightCarObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        _rightCarPooling.Enqueue(_rightCarObject);
        _rightCarDistance += Random.Range(40, 55);
    }
    private void RightCarSpawn()
    {       
        GameObject _rightCarObject = _rightCarPooling.Dequeue();        
        _rightCarObject.SetActive(true);
        _rightCarObject.transform.position = new Vector3(1.5f, 0.89f, RightObject.transform.position.z + _rightz);        
        _rightCarObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        RightObject = _rightCarObject;
        _rightCarPooling.Enqueue(_rightCarObject);        
    }

    private void LeftCarSpawnControl()
    {
        if (_poolingScript._roadPositionz - 10 > LeftObject.transform.position.z - _leftz)
        {
            _leftz = Random.Range(60,65);
            LeftCarSpawn();
        }
    }
    private void StartLeftCarSpawn()
    {
        
        GameObject _leftCarObject = _leftCarPooling.Dequeue();
        LeftObject = _leftCarObject;
        _leftCarObject.SetActive(true);
        _leftCarObject.transform.position = new Vector3(-1.5f, 0.89f, 30);
        _leftCarObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        _leftCarPooling.Enqueue(_leftCarObject);
        _leftCarDistance += Random.Range(60,65);
              
    }
    private void LeftCarSpawn()
    {
        GameObject _leftCarObject = _leftCarPooling.Dequeue();
        _leftCarObject.SetActive(true);
        _leftCarObject.transform.position = new Vector3(-1.5f, 0.89f,_leftCarDistance);
        _leftCarObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        LeftObject = _leftCarObject;
        _leftCarPooling.Enqueue(_leftCarObject);
        _leftCarDistance += Random.Range(60, 65);
    }    
    //private void StartCarSpawn()
    //{
    //    while (_randomCarSpawnPositionz < _poolingScript._roadPositionz - 10)
    //    {
    //        int _rundomNumber = Random.Range(1, 20);
    //        _randomCarDistance += Random.Range(10, 20);
    //        if (_rundomNumber % 2 == 0)
    //        {
    //            GameObject _leftCarObject = _carPooling.Dequeue();
    //            _leftCarObject.SetActive(true);
    //            _leftCarObject.transform.position = new Vector3(-1.5f, 0.89f, _randomCarSpawnPositionz);
    //            _leftCarObject.transform.rotation = Quaternion.Euler(0, 90, 0);
    //            if (_leftCarObject.transform.position.z < _playerCarObject.transform.position.z)
    //            {
    //                _leftCarObject.SetActive(false);
    //                _carPooling.Enqueue(_leftCarObject);
    //            }
    //        }
    //        else
    //        {
    //            GameObject _rightCarObject = _carPooling.Dequeue();
    //            _rightCarObject.SetActive(true);
    //            _rightCarObject.transform.position = new Vector3(1.5f, 0.89f, _randomCarSpawnPositionz);
    //            _rightCarObject.transform.rotation = Quaternion.Euler(0, 270, 0);
    //            if (_rightCarObject.transform.position.z < _playerCarObject.transform.position.z)
    //            {
    //                _rightCarObject.SetActive(false);
    //                _carPooling.Enqueue(_rightCarObject);
    //            }
    //        }
            
    //    }        
    //}

    
    IEnumerator LNormalTimeSpawn()
    {
        while (true)
        {
            if (!_leftSpawn)
            {
                LeftCarSpawn();                
            }            
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
    }
    IEnumerator LShortTimeSpawn()
    {
        while(true)
        {
            if (_leftSpawn)
            {
                LeftCarSpawn();                
            }
            yield return new WaitForSeconds(Random.Range(1, 2));
        }        
    }
    
}
