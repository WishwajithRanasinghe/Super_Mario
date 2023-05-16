using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10f,_jumpForce = 10f;
    private Rigidbody2D _rBody;
    [SerializeField]
    private SpriteRenderer _spRenderer;
    private float _scaleX;

    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
       

        
    }//Start


    private void Update()
    {
        PlayerMovemant();
        PlayerJump();
 
    }//Update
    private void PlayerMovemant()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");

        _rBody.velocity = new Vector2(_horizontalInput* _moveSpeed,0f);

        if(_horizontalInput < 0)
        {
            transform.localScale = new Vector3(_scaleX* -1,transform.localScale.y,transform.localScale.z);
            //_spRenderer.flipX = true;
        }
        if(_horizontalInput > 0)
        {
            transform.localScale = new Vector3(_scaleX* 1,transform.localScale.y,transform.localScale.z);
            //_spRenderer.flipX = false;
        }

    }//PlayerMovemant
    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rBody.AddForce(Vector2.up*_jumpForce);
        }


    }//PlayerJump

}//Class
