using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool _isGrounded = false;
    [SerializeField] private GameObject _destroyEffect;
    

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

    }
    
}//Class
