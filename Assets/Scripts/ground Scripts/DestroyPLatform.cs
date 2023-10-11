using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPLatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _destroyTime = 2f;
    private Rigidbody2D _rBody;
    private BoxCollider2D _collider;
    private bool _platerHit;

    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _rBody.isKinematic = true;
        _collider = GetComponent<BoxCollider2D>();
        
    }//Start

    // Update is called once per frame
    private void Update()
    {
        if(_platerHit == true)
        {
            _destroyTime -= Time.deltaTime;

            if(_destroyTime <= 0)
            {
                _destroyTime = 0;
                _collider.isTrigger = true;
                _rBody.isKinematic = false;
                Destroy(this.gameObject,2f);
            }
        }
        
        
    }//Update
    public void DownPlatform(bool platformHit)
    {
        _platerHit = platformHit;
        

    }//DownPlatform
}//Class
