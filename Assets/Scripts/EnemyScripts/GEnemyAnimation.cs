using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool _hitPlayer;
    private CircleCollider2D _collider;
    private Rigidbody2D _rBody;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<CircleCollider2D>();      
        _rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_hitPlayer == true)
        {
            _collider.isTrigger = true;
            _rBody.isKinematic = true;
        }
        Animation();
    }
    private void Animation()
    {
        if(_hitPlayer == true)
        {
            _animator.SetTrigger("HitPlayer");
        }
    }//Animation
}//Class
