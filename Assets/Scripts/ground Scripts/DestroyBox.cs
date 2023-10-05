using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private int _helth = 100;
    [SerializeField] private GameObject _lastPlat;
    [SerializeField] private GameObject _power;
    private void Update()
    {
        Vector3 powerPosition = new Vector3(transform.position.x,transform.position.y + 1f,transform.position.z);
        if(_helth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(_lastPlat,transform.position,Quaternion.identity);
            Instantiate(_power,powerPosition,Quaternion.identity);
        }
    }//Update
    public void Damage(int _damageValue)
    {
        _helth -= _damageValue;
    }//Damage
}
