using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinPad : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _jumpForce = 20f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerMove>() != null)
            {
                if(collision.gameObject.transform.position.y > transform.position.y+0.3f)
                {
                    _animator.SetTrigger("SpJump");
                    collision.gameObject.GetComponent<PlayerMove>().PlayerJump(_jumpForce);
                }
                
            }
        }
    }
}//Class

