using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dramadrama : MonoBehaviour
{

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



    private bool _countingDown = false;

    private bool _endGame = false;

    public int Timer = 50;

    void Start()
    {
       _maintainHeights = _pinguParent.GetComponentsInChildren<MaintainHeight>();
       _holdUprights = _pinguParent.GetComponentsInChildren<HoldUpright>();

        _text.text = "Ah what a wonderful and peaceful incestuous penguin colony";
    }

   
    void Update()
    {

        //TODO
        //set up some kind of timer to decide when to set drama state, like after X amount of calm time
        //set up controller logic to light up in drama state, and set resolve drama or lose state 
        //extra text for telling users what controls are etc 
        //flesh out rest of text in game etc. 
    

        //btw... game starts from splash scene 

        // test keys 
        if (Input.GetKeyDown(KeyCode.D))
        {
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

        _text.text = string.Empty;
    }

    public void SetLoseState()
    {


        _text.text = " Oh no... you did not manage to save the colony... Better luck next time (if there is a next time)";


        _countingDown = true;
        _endGame = true;

        
    }

}
