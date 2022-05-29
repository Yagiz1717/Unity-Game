using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingScript : MonoBehaviour
{
    public Queue<GameObject> _roadPooling;
    public Queue<GameObject> _buildPooling;

    //Build
    [SerializeField] private GameObject _buildPrefabObjectOne;
    [SerializeField] private GameObject _buildPrefabObjectTwo;
    [SerializeField] private GameObject _buildPrefabObjectThree;
    [SerializeField] private GameObject _buildPrefabObjectFour;

    [SerializeField] private GameObject _roadPrefabObject;
        

    [SerializeField] private GameObject _playerCarObject;

    private int _poolSize = 60;
    public int _roadPositionz = 0;
    private int _randomNumber;

    public int _buildPositionz;

    private void Start()
    {
        StartCoroutine(nameof(RoadChangePosition));
    }
    private void Awake()
    {

        _roadPooling = new Queue<GameObject>();
        _buildPooling = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            
            GameObject _buildObject;

            _randomNumber = Random.Range(1,100);
            _buildPositionz += 7;
            _roadPositionz += 6;
            if (_randomNumber < 25)
            {
                
                _buildObject = Instantiate(_buildPrefabObjectOne, new Vector3(0, 0, _buildPositionz), Quaternion.identity);
                _buildPooling.Enqueue(_buildObject);                
            }
            else if (_randomNumber < 50)
            {
                
                _buildObject = Instantiate(_buildPrefabObjectTwo, new Vector3(0, 0, _buildPositionz), Quaternion.identity);
                _buildPooling.Enqueue(_buildObject);                
            }
            else if (_randomNumber < 75)
            {
                
                _buildObject = Instantiate(_buildPrefabObjectThree, new Vector3(0, 0, _buildPositionz), Quaternion.identity);
                _buildPooling.Enqueue(_buildObject);                
            }
            else
            {
               
                _buildObject = Instantiate(_buildPrefabObjectFour, new Vector3(0, 0, _buildPositionz), Quaternion.identity);
                _buildPooling.Enqueue(_buildObject);                
            }

            GameObject _roadObject;
            _roadObject = Instantiate(_roadPrefabObject);            
            _roadObject.transform.position = new Vector3(0, 0.1f, _roadPositionz);
            _roadPooling.Enqueue(_roadObject);            
        }   
    }       
            
    IEnumerator RoadChangePosition()
    {       
        while (true)
        {   
            if (_roadPositionz - _playerCarObject.transform.position.z < 300)
            {
                GameObject _roadObject = _roadPooling.Dequeue();               
                _roadPositionz += 6;               
                _roadObject.transform.position = new Vector3(0, 0.1f, _roadPositionz);                               
                _roadPooling.Enqueue(_roadObject);
            }
            if (_buildPositionz-_playerCarObject.transform.position.z<340)
            {
                GameObject _buildObject = _buildPooling.Dequeue();
                _buildPositionz += 7;
                _buildObject.transform.position = new Vector3(0, 0.1f, _buildPositionz);
                _buildPooling.Enqueue(_buildObject);
            }
            yield return new WaitForSeconds(0.1f);
        }   
    }       
}           
