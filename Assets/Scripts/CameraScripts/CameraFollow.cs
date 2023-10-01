using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _miniDistance = 0f ,_maxDistance = 80f;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

   
    private void Update()
    {
        //if(_player == null) {return;}

        Vector3 _camPosition = transform.position;
        Vector3 _playerPosition = _player.transform.position;      
        
        if( _playerPosition.x > _miniDistance && _playerPosition.x < _maxDistance)
        {
            _camPosition = new Vector3( _playerPosition.x,_camPosition.y,_camPosition.z);
            _camPosition.x = Mathf.Clamp(_camPosition.x,_miniDistance,_maxDistance);
        }
        transform.position = _camPosition;
        
    }
}//Class
