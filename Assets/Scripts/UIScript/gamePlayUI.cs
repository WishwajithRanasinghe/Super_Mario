using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _harts;
    [SerializeField] private Sprite _goldStar;
    [SerializeField] private Image[] _star; 
    [SerializeField] private Image _coinLevel;
    [SerializeField] private Image _timeLevel;
    [SerializeField] private GameObject _TimeBar;
    [SerializeField] private Text _bulletAmount;
    private int _bullets;
    private float _levelCoin = 0,_coin = 0;
    //private float _maxCoin = 100f;
    private float _time,_startTime;
    private bool _isOn = false;
    private int _helth = 5;
    private AudioScript _audio;



    private void Awake()
    {
        _audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
    }//Awake
    private void Start()
    {
        _helth = 5;
        _levelCoin = 0;
    //_TimeBar.SetActive(false);
        
    }

    private void Update()
    {
        HelthLevel();
        CoinLevel();
        TimeLevel();
        BulletUpdate();
    }
    public void Helth(int helth)
    {
        _helth += helth;
        if(_helth <= 0)
        {
            _helth = 0;
            Debug.Log("GameOver!");
        }
    }
    private void HelthLevel()
    {
        if(_helth == 5)
        {
            _harts[4].SetActive(true);
            _harts[3].SetActive(false);
            _harts[2].SetActive(false);
            _harts[1].SetActive(false);
            _harts[0].SetActive(false);
        }
        if(_helth == 4)
        {
            _harts[4].SetActive(false);
            _harts[3].SetActive(true);
            _harts[2].SetActive(false);
            _harts[1].SetActive(false);
            _harts[0].SetActive(false);
        }
        if(_helth == 3)
        {
            _harts[4].SetActive(false);
            _harts[3].SetActive(false);
            _harts[2].SetActive(true);
            _harts[1].SetActive(false);
            _harts[0].SetActive(false);
        }
        if(_helth == 2)
        {
            _harts[4].SetActive(false);
            _harts[3].SetActive(false);
            _harts[2].SetActive(false);
            _harts[1].SetActive(true);
            _harts[0].SetActive(false);
        }
        if(_helth == 1)
        {
            _harts[4].SetActive(false);
            _harts[3].SetActive(false);
            _harts[2].SetActive(false);
            _harts[1].SetActive(false);
            _harts[0].SetActive(true);
        }
        if(_helth == 0)
        {
            _harts[4].SetActive(false);
            _harts[3].SetActive(false);
            _harts[2].SetActive(false);
            _harts[1].SetActive(false);
            _harts[0].SetActive(false);

        }
    }//HelthLevel
    public void Coin(float coin)
    {
        _levelCoin += coin;
    }//Coin
    
    
    
    private void CoinLevel()
    {
        if(_levelCoin >= 100)
        {
            _coin += _levelCoin;
            if(_coin < 300)
            {
                _levelCoin = 0;
            }
        }
        if(_coin == 100)
        {
            _star[0].sprite = _goldStar;
        
        }
        if(_coin == 200)
        {
            _star[1].sprite = _goldStar;
 
        }
        if(_coin == 300)
        {
            _star[2].sprite = _goldStar;
            _coin = 300;
            
        }
        _coinLevel.rectTransform.localScale = new Vector3(_levelCoin * 84/100,1f); 
        
    }//CoinLevel
    public void Time(float time ,float startTime,bool isOn)
    {
        _time = time; 
        _isOn = isOn;
        _startTime = startTime;
    }
    private void TimeLevel()
    {
        
        
        if(_isOn == true)
        {

            _TimeBar.SetActive(true);
            _timeLevel.rectTransform.localScale = new Vector3(_time * 84/_startTime,1f);
        }
        else
        {

            _TimeBar.SetActive(false);
        }
    }//TimeLevel
    public void BulletAmount(int bullets)
    {
        _bullets = bullets;
    }//BulletAmount
    private void BulletUpdate()
    {
        _bulletAmount.text = _bullets.ToString();
    }
}
