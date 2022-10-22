using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dramadrama : MonoBehaviour
{
    public static Dramadrama Instance { get; private set; }
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _calmMusic;

    [SerializeField]
    private AudioClip _dramaMusic;

    [SerializeField]
    private List<string> _dramaTexts = new List<string>();

    [SerializeField]
    private GameObject _pinguParent;
    
    private MaintainHeight[] _maintainHeights = new MaintainHeight[0];
    private HoldUpright[] _holdUprights = new HoldUpright[0];

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private TMP_Text _dramaCountText;

    [SerializeField]
    private AudioSource _sfx;

    private int _dramaCount = 0;


    private bool _countingDown = false;

    private bool _endGame = false;

    public int Timer = 5;
    private float dramaTimer = 3f;
    private float dramaTimerLength = 3f;

    void Start()
    {
        Instance = this;
       _maintainHeights = _pinguParent.GetComponentsInChildren<MaintainHeight>();
       _holdUprights = _pinguParent.GetComponentsInChildren<HoldUpright>();

        _text.text = "Ah what a wonderful and peaceful incestuous penguin colony";

        _dramaCountText.text = _dramaCount.ToString();
    }

   
    void Update()
    {

      

        // test keys 
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (SimpleSerial.Instance != null)
            {
            SimpleSerial.Instance.Write(FetchArray.Instance.PickRandom());

            }
            SetDrama();
        }

        if (Input.GetKeyDown(KeyCode.R))
            {
            ResolveDrama();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetLoseState();
        }

        if (_countingDown)
        {
            Timer--;

            if (Timer <= 0)
            {
                _countingDown = false;
                if (_endGame == true)
                {
                    SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

                }
            }
        }
        else if (!_endGame) 
        {
            if(dramaTimer > 0)
            {
                dramaTimer -= Time.deltaTime;
                if (dramaTimer < 0)
                {
                    if (SimpleSerial.Instance != null)
                    {
                        SimpleSerial.Instance.Write(FetchArray.Instance.PickRandom());

                    }
                    SetDrama();
                }
            }
            
        }
    }


    public void SetDrama()
    {

        _audioSource.clip = _dramaMusic;
        _audioSource.Play();


        foreach (MaintainHeight mh in _maintainHeights)
        {
            mh.force = 10;
        }


        foreach (HoldUpright hu in _holdUprights)
        {
            hu.force = 10;
        }

        _text.text = _dramaTexts[Random.Range(0, _dramaTexts.Count)];

      
    }

    public void ResolveDrama()
    {
        dramaTimer = dramaTimerLength;
        dramaTimerLength -= 0.1f; //maybe we can put this on a curve so the difficulty isnt linearly increasing?

        _audioSource.clip = _calmMusic;
        _audioSource.Play();

        _text.text = "Well done, the colony is drama free... for now!";

        foreach (MaintainHeight mh in _maintainHeights)
        {
            mh.force = 2;
        }


        foreach (HoldUpright hu in _holdUprights)
        {
            hu.force = 2;
        }

        _dramaCount++;
        if (_dramaCount > 10) SetWinState();
        _dramaCountText.text = _dramaCount.ToString();
    }

    public void SetLoseState()
    {

        _sfx.Play();
        _text.text = " Oh no... you did not manage to save the colony... Better luck next time (if there is a next time)";


        _countingDown = true;
        _endGame = true;

        
    }
    public void SetWinState()
    {
        _sfx.Play();
        _text.text = "You kept the colony together! congrats!!";


        _countingDown = true;
        _endGame = true;
    }

}
