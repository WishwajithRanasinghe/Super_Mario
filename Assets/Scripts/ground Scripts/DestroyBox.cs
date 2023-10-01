using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private int _helth = 100;
    [SerializeField] private GameObject _lastPlat;
    private void Update()
    {
        if(_helth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(_lastPlat,transform.position,Quaternion.identity);
        }
    }
    public void Damage(int _damageValue)
    {
        _helth -= _damageValue;
    }
}
