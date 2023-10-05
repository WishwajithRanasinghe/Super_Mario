using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool _isGrounded = false;
    public bool _isEnemyKill = false;
    [SerializeField] private GameObject _destroyEffect; // mis;
    public bool hit = false;
    private float _hitTime = 0.3f;
    [SerializeField] private int _point;

    private float _starthitTime;

    private void Start()
    {
        _starthitTime = _hitTime;
    }//Start

    private void Update()
    {
        if(hit == true)
        {
            _hitTime -= Time.deltaTime;
        }
        if(_hitTime <= 0)
        {
            _hitTime = _starthitTime;
            hit = false;
        }

        if(_isEnemyKill == true)
        {
            _point ++;
            _isEnemyKill = false;
        }
    }//Update
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Ground" :
                if(collision.gameObject.transform.position.y <= transform.position.y)
                {
                    _isGrounded = true;

                }
            break;

            case "DestroyPlat":
                if(collision.gameObject.GetComponent<DestroyBox>() == null){return;}
                if(collision.gameObject.transform.position.y > transform.position.y + 0.5f)
                {
                    collision.gameObject.GetComponent<DestroyBox>().Damage(25);
                    Instantiate(_destroyEffect,collision.transform.position,Quaternion.identity);
                
                }
                else
                {
                    _isGrounded = true;
                }
            break;

            case "Enemy":
                if(collision.gameObject.transform.position.y <= transform.position.y - 0.4f)
                {
                
                    Destroy(collision.gameObject,2f);
                    if(collision.gameObject.GetComponent<GEnemyAnimation>() != null)
                    {
                        collision.transform.gameObject.GetComponent<GEnemyAnimation>()._hitPlayer = true;
                    }
                    _point ++;
                    _isGrounded = true;
                }
                else
                {
                    Debug.Log("HitEnemy !");
                    hit = true;
                    _isGrounded = true;
                }
            break;
            case "FlyEnemy":
                if(collision.gameObject.transform.position.y <= transform.position.y - 0.4f)
                {
                
                    Destroy(collision.gameObject,3f);
                    if(collision.gameObject.GetComponent<FlyEnemy>() != null)
                    {
                        collision.transform.gameObject.GetComponent<FlyEnemy>().SetDie();
                    }
                    _point ++;
                    _isGrounded = true;
                }
                else
                {
                    Debug.Log("HitEnemy !");
                    hit = true;
                    _isGrounded = true;
                }
            break;
            case "MistryPlat":
                if(collision.gameObject.GetComponent<DestroyBox>() == null){return;}
                if(collision.gameObject.transform.position.y > transform.position.y + 0.5f)
                {
                    collision.gameObject.GetComponent<DestroyBox>().Damage(100);
                    Instantiate(_destroyEffect,collision.transform.position,Quaternion.identity);
                
                }
                else
                {
                    _isGrounded = true;
                }
            break;

            case "Spites":
                _isGrounded = true;
            break;

            case "Flag":
                _isGrounded = true;
            break;

            case "Portal":
                _isGrounded = true;
            break;

        }

    }//OnCollisionEnter2D

    //Powers
    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.transform.tag)
        {
            case "Coin":
                Debug.Log("Coin");
                Destroy(collider.gameObject);
            break;

            case "Bstar":
                Debug.Log("Bstar");
                Destroy(collider.gameObject);
            break;

            case "Flower":
                Debug.Log("Flower");
                Destroy(collider.gameObject);
            break;
            case "Mushroom":
                Debug.Log("Mushroom");
                Destroy(collider.gameObject);

            break;
            
        
        }
    }//OnTriggerEnter2D
    
}//Class
