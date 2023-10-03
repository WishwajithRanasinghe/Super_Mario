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
    private Vector2 _direction;
    private float _scaleX;
    private PlayerCollision _collision;


    //animation

    public bool isJump = false,isWalk = false,isCover = false;

    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
        _collision = GetComponent<PlayerCollision>();
       

        
    }//Start


    private void Update()
    {
        PlayerJump();
        GetInput();

        
 
    }//Update
    private void FixedUpdate()
    {
        PlayerMovemant();
    }
    private void GetInput()
    
    {
        _direction.x = Input.GetAxis("Horizontal") ;


    }
    private void PlayerMovemant()
    {
        
        _rBody.MovePosition(_rBody.position +_direction * _moveSpeed * Time.fixedDeltaTime);
        

        if(_direction.x < 0)
        {
            transform.localScale = new Vector3(_scaleX* -1,transform.localScale.y,transform.localScale.z);
            if(_collision._isGrounded == true && _direction.x < -0.2)
            {
                isWalk = true; 
            }
            
        }
        else if(_direction.x > 0)
        {
            transform.localScale = new Vector3(_scaleX* 1,transform.localScale.y,transform.localScale.z); 
            if(_collision._isGrounded == true && _direction.x > 0.2)
            {
                isWalk = true; 
            }
        }
        else
        {
            if(_collision._isGrounded == false || _direction.x == 0 )
            {
                isWalk = false;
            }
            
        }
        
        if(_collision._isGrounded == true)
        {
            isJump = false;
            _direction.y = Mathf.Max(_direction.y,-1f);
        }
        else
        {
            _direction += Physics2D.gravity * Time.deltaTime;
        }

    }//PlayerMovemant
    private void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && _collision._isGrounded == true) 
        {
            isJump = true;
            _collision._isGrounded = false;
            _direction = Vector2.up * _jumpForce;
        }


    }//PlayerJump
    private void PlayerCover()
    {
        if(Input.GetKey(KeyCode.S))
        {
            isCover = true;
        }
        else
        {
            isCover = false;
        }
    }
    

}//Class
