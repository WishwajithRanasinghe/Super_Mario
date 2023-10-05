using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private BoxCollider2D _collider; 
    private Animator _animator;
    private GameObject _player;
    [SerializeField] private float _flySpeed = 2f;
    [SerializeField] private float _flyDistance = 6;
    [SerializeField] private GameObject _fireRock;
    [SerializeField] private Transform _fireRockPos;
    private bool _isLeft = true;

    private float _sizeX;
    private Vector3 _startPosition;
    private bool _isHit;
    private bool _isDrop;
    
    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _rBody.isKinematic = true;
        _collider = GetComponentInChildren<BoxCollider2D>();
        _collider.isTrigger = false;
        _animator = GetComponentInChildren<Animator>();
        _startPosition = _rBody.position;
        _sizeX = transform.localScale.x;
        _player = GameObject.FindGameObjectWithTag("Player");
    }//Start

    private void Update()
    {
        if(_rBody.position.x < (_startPosition.x -_flyDistance/2) || _rBody.position.x > (_startPosition.x + _flyDistance/2))
        {
            if(_isLeft == true)
            {
                _isLeft = false;
            }
            else
            {
                _isLeft = true;
            }
        }
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x,(_startPosition.x -_flyDistance/2),(_startPosition.x + _flyDistance/2));
        transform.position = position;
        
        DropFireRock();
    }//Update
    private void FixedUpdate()
    {
        EnemyFly();
    }//FixedUpdate

    private void EnemyFly()
    {
        if(_isHit == false)
        {
            if(_isLeft == true)
            {
                _rBody.MovePosition(new Vector2(_rBody.position.x - 1 *_flySpeed* Time.fixedDeltaTime,_rBody.position.y));
                transform.localScale = new Vector3(_sizeX * 1,transform.localScale.y,transform.localScale.z);
            }
            else
            {
                _rBody.MovePosition(new Vector2(_rBody.position.x + 1 *_flySpeed* Time.fixedDeltaTime,_rBody.position.y));
                transform.localScale = new Vector3(_sizeX * -1,transform.localScale.y,transform.localScale.z);
            }
        }
        else
        {
            _rBody.position = new Vector3(_rBody.position.x,_rBody.position.y);
        }
        
        


    }//EnemyFly
    private void DropFireRock()
    {
        if(_player != null)
        {
            if((_player.transform.position.x + 0.1f) > transform.position.x  && (_player.transform.position.x - 0.1f) < transform.position.x)
            {
                if(_isDrop == false)
                {   
                    _isDrop = true;
                    _animator.SetBool("IsDrop",true);
                    Instantiate(_fireRock,_fireRockPos.position,Quaternion.identity);
                    
                }

            }
        }
        
    }//BirdFire
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.transform.tag)
        {
            case "Rock":
            SetDie();
            break;
            case "Player":
            break;
            default:
                if(_isLeft == true)
                {   
                    _isLeft = false;
                }
                else
                {
                    _isLeft = true;
                }
            break;
        }
        
    }//OnCollisionEnter2D
    public void SetDie()
    {
        _animator.SetBool("IsHit",true);
        _rBody.isKinematic = false;
        _collider.isTrigger = true;
        
        _isHit = true;
    }//SetDie
    
}//Class
