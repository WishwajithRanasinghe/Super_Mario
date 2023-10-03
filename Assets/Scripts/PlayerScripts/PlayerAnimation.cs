using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    private PlayerMove _moveScript;
    private PlayerCollision _collision;
    
    private void Start()
    {
        //_animator = GetComponentInChildren<Animator>();
        _moveScript = GetComponent<PlayerMove>();
        _collision = GetComponent<PlayerCollision>();
    }

    private void Update()
    {
        Animation();
    }
    private void Animation()
    {
        if(_moveScript.isJump == true)
        {
            _animator.SetBool("IsJump",true);
        }
        else
        {
            _animator.SetBool("IsJump",false);
        }
        if(_collision.hit == true)
        {
            _animator.SetTrigger("IsHit");
        }
        if(_moveScript.isWalk == true)
        {
            _animator.SetBool("IsWalk",true);
        }
        else
        {
            _animator.SetBool("IsWalk",false);
        }
        if(_moveScript.isCover == true)
        {
            _animator.SetBool("IsCover",true);
        }
        else
        {
            _animator.SetBool("IsCover",false);
        }
    }
}//Class
