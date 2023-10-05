using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _miniDistanceX = 0f ,_maxDistanceX = 80f;
    [SerializeField] private float _miniDistanceY = 0f ,_maxDistanceY = 80f;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

   
    private void Update()
    {
        if(_player == null) {return;}

        Vector3 _camPosition = transform.position;
        Vector3 _playerPosition = _player.transform.position;      
        
        if( _playerPosition.x > _miniDistanceX && _playerPosition.x < _maxDistanceX)
        {
            _camPosition = new Vector3( _playerPosition.x,_camPosition.y,_camPosition.z);
            _camPosition.x = Mathf.Clamp(_camPosition.x,_miniDistanceX,_maxDistanceX);
        }
        if( _playerPosition.y > _miniDistanceY && _playerPosition.y < _maxDistanceY)
        {
            _camPosition = new Vector3( _camPosition.x,_playerPosition.y,_camPosition.z);
            _camPosition.y = Mathf.Clamp(_camPosition.y,_miniDistanceY,_maxDistanceY);
        }
        transform.position = _camPosition;
        
    }
}//Class
