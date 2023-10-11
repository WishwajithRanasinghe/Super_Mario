using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip _coin;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _items;
    [SerializeField] private AudioClip _powerUp;
    [SerializeField] private AudioClip _newItems;
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioClip _fire;
    [SerializeField] private AudioClip _hitEnemy;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        
    }//Awake

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Coin()
    {
        _audio.PlayOneShot(_coin);
    }
    public void Jump()
    {
        _audio.PlayOneShot(_jump);
    }
    public void Items()
    {
        _audio.PlayOneShot(_items);
    }
    public void PowerUp()
    {
        _audio.PlayOneShot(_powerUp);
    }
    public void NewItems()
    {
        _audio.PlayOneShot(_newItems);
    }
    public void Die()
    {
        _audio.PlayOneShot(_die);
    }
    public void Fire()
    {
        _audio.PlayOneShot(_fire);
    }
    public void HitEnemy()
    {
        _audio.PlayOneShot(_hitEnemy);
    }
}
