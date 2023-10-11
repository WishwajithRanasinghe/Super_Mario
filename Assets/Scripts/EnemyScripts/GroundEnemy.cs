using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    private Rigidbody2D _rBody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _walkDistance;
    private bool _isLaft = true;
    private GEnemyAnimation _animScript;
    
    private Vector2 _startPosition;
    private int _dieCheck;
    private float _scaleX;
   
    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _startPosition = _rBody.position;
        _animScript = GetComponent<GEnemyAnimation>();
        _scaleX = transform.localScale.x;
        
    }

    private void Update()
    {  
        if(_rBody.position.x <= (_startPosition.x- _walkDistance/2) || _rBody.position.x >= (_startPosition.x + _walkDistance/2) )
        {
            if(_isLaft == true)
            {
                _isLaft = false;
            }
            else
            {
                _isLaft = true;
            }
        }
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x,(_startPosition.x -_walkDistance/2),(_startPosition.x + _walkDistance/2));
        transform.position = position;
     
    }
    private void FixedUpdate()
    {
        if(_animScript._hitPlayer == true)
        {
            _rBody.position = new Vector3(_rBody.position.x,_rBody.position.y);
        }
            
        else
        {
            if(_isLaft == true)
            {
                _rBody.MovePosition(new Vector3(_rBody.position.x + 1 * _moveSpeed * Time.fixedDeltaTime,_rBody.position.y));
                transform.localScale = new Vector3(_scaleX * -1,transform.localScale.y,transform.localScale.z);
            }
            else
            {
                _rBody.MovePosition(new Vector3(_rBody.position.x - 1 * _moveSpeed * Time.fixedDeltaTime,_rBody.position.y));
                transform.localScale = new Vector3(_scaleX * 1,transform.localScale.y,transform.localScale.z);
           
            }
        }
        

 
    }//FixedUpdate
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.transform.tag == "FlowerBullet")
        {
            if(collision.gameObject.GetComponent<FlowerBullet>() != null)
            {
                collision.gameObject.GetComponent<FlowerBullet>().DestroyObject();

            }
            
            _animScript._hitPlayer = true;
            Destroy(this.gameObject,2f);
            Debug.Log("Destroy");
        }
        
        if(collision.transform.tag != "Ground" || collision.transform.tag != "FlowerBullet")
        {
            if(_isLaft == true)
            {
                _isLaft = false;
            }
            else
            {
                _isLaft = true;
            }

        }
        
    }//OnCollisionEnter
}//Class
