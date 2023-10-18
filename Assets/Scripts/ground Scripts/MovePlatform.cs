using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _moveDistance = 3f;
    [SerializeField] private bool _isHorizontal;

    private Vector3 _startPos;
    private bool _isRight,_isUp,_isPlayer;
    private GameObject _player;


    private void Start()
    {
        _startPos = transform.position;
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }//Start
    // Update is called once per frame
    private void Update()
    {
        if(_isHorizontal == true)
        {
            if(transform.position.x < (_startPos.x - _moveDistance/2) || transform.position.x > (_startPos.x +_moveDistance/2))
            {
                if(_isRight == true)
                {
                    _isRight = false;
                }   
                else
                {
                    _isRight = true;
                }
            }
            if(_isRight == true)
            {
                transform.position = new Vector3(transform.position.x + 1 * _moveSpeed * Time.deltaTime,transform.position.y,transform.position.x);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 1 * _moveSpeed * Time.deltaTime,transform.position.y,transform.position.x);
            }
        }
        else
        {
            if(transform.position.y < (_startPos.y - _moveDistance/2) || transform.position.y > (_startPos.y +_moveDistance/2))
            {
                if(_isUp == true)
                {
                    _isUp = false;
                }   
                else
                {
                    _isUp = true;
                }
            }
            if(_isUp == true)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + 1 * _moveSpeed * Time.deltaTime,transform.position.x);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,transform.position.y - 1 * _moveSpeed * Time.deltaTime,transform.position.x);
            }
        }







        //...........................................
        if(_isPlayer == true)
        {
            if(_player != null)
            {
                _player.GetComponent<Rigidbody2D>().isKinematic = true;
                _player.gameObject.transform.SetParent(this.gameObject.transform);
                
            }
        }
        else
        {
            if(_player != null)
            {
                _player.GetComponent<Rigidbody2D>().isKinematic = false;
                _player.gameObject.transform.SetParent(p: null);
            }
        }
        
        


        
        
    }//Update 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.tag == ("Player"))
        {
            _isPlayer = true;
        }
    }
    private void OnCollisionExit2D(Collider2D collision)
    {
        if(collision.transform.tag == ("Player"))
        {
            _isPlayer = false;
        }
    }
}//Class
