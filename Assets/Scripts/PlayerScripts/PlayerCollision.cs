using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool _isGrounded = false,isMoveplat = false;
    public bool _isEnemyKill = false;
    [SerializeField] private GameObject _destroyEffect; // mis;
    public bool hit = false;
    private bool _isSafe;
    private float _hitTime = 0.3f;
    [SerializeField] private int _point;
    private Vector3 _playerScale;
    [SerializeField] private float _safeTime = 5f;
    private float _startsafeTime;
    private float _starthitTime;
    private GameObject _ui;
    public int _bullet;
    private AudioScript _audio;

    private void Awake()
    {  
        _playerScale = gameObject.GetComponent<Transform>().localScale;
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
        _ui = GameObject.FindGameObjectWithTag("UI");
    }//Awake
    private void Start()
    {
        _starthitTime = _hitTime;
        _startsafeTime = _safeTime;
        
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

        //.........EnemyKill

        if(_isEnemyKill == true)
        {
            _point ++;
            _isEnemyKill = false;
        }
        
        //..........Safe
        if(_isSafe == true)
        {

            _safeTime -= Time.deltaTime;
            
        }
        if(_safeTime <= 0)
        {
            _safeTime = 0;
            _isSafe = false;
        }

        //..........UI
        if(_ui != null)
        {
            _ui.GetComponent<gamePlayUI>().Time(_safeTime,_startsafeTime,_isSafe);
            _ui.GetComponent<gamePlayUI>().BulletAmount(_bullet);
        }

        //.........Bullets
        if(_bullet <= 0)
        {
            _bullet = 0;
        }
    }//Update

    /*public void ScoreSystem(int points)
    {
        _point += points;

    }*/
    private void HelthInSystum()
    {
        if(_ui != null)
        {
            _ui.GetComponent<gamePlayUI>().Helth(+1);
        }
        
    }
    private void HelthDeSystum()
    {
        if(_ui != null)
        {
            _ui.GetComponent<gamePlayUI>().Helth(-1);
        }
    }
    private void CollisionCoin()
    {
        if(_ui != null)
        {
            _ui.GetComponent<gamePlayUI>().Coin(10f);
        }
    }

    

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
                    
                    //ScoreSystem(10);
                    _isGrounded = true;
                }
                else
                {
                    _isGrounded = true;
                    if(_isSafe == true) {return;}
                    _audio.HitEnemy();

                    Debug.Log("HitEnemy !");
                    transform.localScale = _playerScale;
                    hit = true;
                    
                    HelthDeSystum();
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
                    _isGrounded = true;
                    if(_isSafe == true) {return;}
                    Debug.Log("HitEnemy !");
                    _audio.HitEnemy();
                    transform.localScale = _playerScale;
                    hit = true;
                    
                    HelthDeSystum();
                }
            break;
            case "MistryPlat":
                if(collision.gameObject.GetComponent<DestroyBox>() == null){return;}
                if(collision.gameObject.transform.position.y > transform.position.y + 0.5f)
                {
                    collision.gameObject.GetComponent<DestroyBox>().Damage(100);
                    Instantiate(_destroyEffect,collision.transform.position,Quaternion.identity);
                    _audio.NewItems();
                }
                else
                {
                    _isGrounded = true;
                }
            break;
            case "DownPlat":
                if(collision.gameObject.transform.position.y <= transform.position.y)
                {
                    if(collision.gameObject.GetComponent<DestroyPLatform>() != null)
                    {
                        collision.gameObject.GetComponent<DestroyPLatform>().DownPlatform(true);
                    }
                    _isGrounded = true;

                }

            break;

            case "Spites":
                _isGrounded = true;
                if(_isSafe == true) {return;}
                
                Debug.Log("HitEnemy !");
                transform.localScale = _playerScale;
                _audio.HitEnemy();

                hit = true;
                HelthDeSystum();
            break;




            
            ////////......................
            case "MovePlat":
                isMoveplat = true;
                _isGrounded = true;
                

            break;

            case "Flag":
                _isGrounded = true;
            break;

            case "Portal":
                _isGrounded = true;
            break;
            default:
                if(collision.gameObject.transform.position.y < transform.position.y)
                {
                    _isGrounded = true;
                }
                
            break;

        }

    }//OnCollisionEnter2D
    private void OnCollisionExit2D(Collision2D collision)
    {
       /* switch (collision.transform.tag)
        {
            case "Ground" :
                _isGrounded = false;
            break;

            case "DestroyPlat":
                _isGrounded = false;
            break;

            case "Enemy":

                _isGrounded = false;
            break;

            case "FlyEnemy":  
               _isGrounded = false;
            break;
            case "MistryPlat":
                _isGrounded = false;
            break;
            case "DownPlat":

                _isGrounded = false;

            break;

            case "Spites":
                _isGrounded = false;
              
            break;

            case "Flag":
                _isGrounded = false;
            break;

            case "Portal":
                _isGrounded = false;
            break;
        }*/
    }

    //Powers
    private void OnTriggerEnter2D(Collider2D collider)
    {
        switch (collider.transform.tag)
        {
            case "Coin":
                Debug.Log("Coin");
                Destroy(collider.gameObject);
                CollisionCoin();
                _audio.Coin();
            break;

            case "Bstar":
                Debug.Log("Bstar");
                _safeTime = _startsafeTime;
                _isSafe = true;
                _audio.Items();

                Destroy(collider.gameObject);
            break;

            case "Flower":
                Debug.Log("Flower");
                _bullet += 5;
                Destroy(collider.gameObject);
                _audio.Items();
            break;
            case "Mushroom":
                Debug.Log("Mushroom");
                transform.localScale = new Vector3(1.5f, 1.5f ,0f);
                _audio.PowerUp();
                Destroy(collider.gameObject);

            break;
            case "Hart":
                HelthInSystum();
                Destroy(collider.gameObject);
                _audio.Items();
            break;
            
            case "Egg":
                if(_isSafe == true) {return;}
                Debug.Log("HitEnemy !");
                transform.localScale = _playerScale;
                hit = true;
                HelthDeSystum();
                Destroy(collider.gameObject);
            break;
            
        
        }

    }//OnTriggerEnter2D
    
}//Class
