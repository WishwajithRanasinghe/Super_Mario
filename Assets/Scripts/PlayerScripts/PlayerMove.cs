using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f,_upForce = 10f;
    private Rigidbody2D _rBody;
    [SerializeField] private SpriteRenderer _spRenderer;
    [SerializeField] private GameObject _flowerBullet;
    [SerializeField] private Transform _bullatpos;
    private Vector2 _direction;
    private float _scaleX;
    private PlayerCollision _collision;
    private AudioScript _audio;

    public bool isLaft;
    


    //animation

    public bool isJump = false,isWalk = false,isCover = false , isFire = false;

    private void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
         _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
        
        _collision = GetComponent<PlayerCollision>();
       

        
    }//Awake
    private void Start()
    {
        _scaleX = transform.localScale.x;
    }//start


    private void Update()
    {
        
        GetInput();
        PlayerCover();
        PlayerFire();
        if(_collision._bullet > 0)
        {
            
        }
        

    }//Update
    private void FixedUpdate()
    {
        PlayerMovemant();
    }//FixedUpdate
    private void GetInput()
    
    {
        _direction.x = Input.GetAxis("Horizontal") ;
        if(Input.GetButtonDown("Jump") && _collision._isGrounded == true) 
        {
            PlayerJump(_upForce);
            
        }


    }//GetInput

    private void PlayerFire()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            if(_collision._bullet > 0)
            {
                Instantiate(_flowerBullet,_bullatpos.position,Quaternion.identity);
                _collision._bullet --;
                isFire = true;
                _audio.Fire();
            }
        }
        if(Input.GetKeyUp(KeyCode.RightControl))
        {
            isFire = false;
        }

    }//PlayerFire
    private void PlayerMovemant()
    {
        
        _rBody.MovePosition(_rBody.position +_direction * _moveSpeed * Time.fixedDeltaTime);
        

        if(_direction.x < 0)
        {

            transform.localRotation = new Quaternion(transform.rotation.x,180f,transform.rotation.z,0f);
            if(_collision._isGrounded == true && _direction.x < -0.2)
            {
                isWalk = true;
                isLaft = true;
            }
            
        }
        else if(_direction.x > 0)
        {
            transform.localRotation = new Quaternion(transform.rotation.x,0f,transform.rotation.z,0f);
            if(_collision._isGrounded == true && _direction.x > 0.2)
            {
                isWalk = true; 
                isLaft = false;
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
            if(_collision.isMoveplat == true)
            {
                _direction.y = Mathf.Max(_direction.y,0f);
            }
            else
            {
            _direction.y = Mathf.Max(_direction.y,-1f);
            }
        }
        else
        {
            _direction += Physics2D.gravity * Time.deltaTime;
        }

    }//PlayerMovemant
    public void PlayerJump(float _jumpForce)
    {

        _audio.Jump(); 
        isJump = true;
        _collision._isGrounded = false;
        _direction = Vector2.up * _jumpForce;
       
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
    }//PlayerCover
    

}//Class
