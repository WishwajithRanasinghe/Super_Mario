using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool _isGrounded = false;
    public bool _isEnemyKill = false;
    [SerializeField] private GameObject _destroyEffect;
    public bool hit = false;
    private float _hitTime = 0.3f;
    [SerializeField] private int _point;

    private float _starthitTime;

    private void Start()
    {
        _starthitTime = _hitTime;
    }

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
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground" || collision.transform.tag == "DestroyPlat" || collision.transform.tag == "MistryPlat")
        {
            if(collision.gameObject.transform.position.y <= transform.position.y)
            {
                _isGrounded = true;

            }
            
            
        }
        if(collision.transform.tag == "DestroyPlat")
        {
            if(collision.gameObject.GetComponent<DestroyBox>() == null){return;}
            if(collision.gameObject.transform.position.y > transform.position.y + 0.5f)
            {
                collision.gameObject.GetComponent<DestroyBox>().Damage(25);
                Instantiate(_destroyEffect,collision.transform.position,Quaternion.identity);
                
            }
            
           // Destroy(_destroyEffect,0.5f);
        }
        if(collision.transform.tag == "Enemy")
        {
            if(collision.gameObject.transform.position.y <= transform.position.y - 0.4f)
            {
                
                Destroy(collision.gameObject,2f);
                if(collision.gameObject.GetComponent<GEnemyAnimation>() != null)
                {
                    collision.transform.gameObject.GetComponent<GEnemyAnimation>()._hitPlayer = true;
                }
                _point ++;
            }
            else
            {
                Debug.Log("HitEnemy !");
                hit = true;

            }

        }

    }
    
}//Class
