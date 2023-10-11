using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBullet : MonoBehaviour
{
    private Rigidbody2D _rBody;
    private Animator _animator;
    [SerializeField] private float _throwForce = 10f;
    [SerializeField] private float _destroyTime = 3f;
    private PlayerMove _playerScript;
    private bool _isDestroy = false;
    private void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        if(_playerScript != null)
        {
            if(_playerScript.isLaft == true)
            {
                _rBody.AddForce(new Vector2(-1,0.5f)*_throwForce);
            }
            else
            {
                _rBody.AddForce(new Vector2(1,0.5f)* _throwForce);
            }   
        }
        
        
    }//Start


    private void Update()
    {
        _destroyTime -= Time.deltaTime;
        if(_destroyTime <= 0)
        {
            _destroyTime = 0;
            DestroyObject();
        }
    }//Update 
    public void DestroyObject()
    {
        _animator.SetTrigger("Explod");
        if(_isDestroy == true)
        {
            Destroy(this.gameObject);
        }
        
    }//DestroyObject
    public void IsDestroy()
    {
        _isDestroy = true;
    }
}//Class
