using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dramadrama : MonoBehaviour
{

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _calmMusic;

    [SerializeField]
    private AudioClip _dramaMusic;

    [SerializeField]
    private List<string> _dramaText = new List<string>();

    [SerializeField]
    private GameObject _pinguParent;
    
    private MaintainHeight[] _maintainHeights = new MaintainHeight[0];
    private HoldUpright[] _holdUprights = new HoldUpright[0];


    // Start is called before the first frame update
    void Start()
    {
       _maintainHeights = _pinguParent.GetComponentsInChildren<MaintainHeight>();
       _holdUprights = _pinguParent.GetComponentsInChildren<HoldUpright>();


    }

    // Update is called once per frame
    void Update()
    {

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

        //todo 
        //some text to describe drama (choose text from list of strings)
        //set force on penguin stronger
    }

    public void ResolveDrama()
    {
        _audioSource.clip = _calmMusic;
        _audioSource.Play();

        foreach (MaintainHeight mh in _maintainHeights)
        {
            mh.force = 2;
        }


        foreach (HoldUpright hu in _holdUprights)
        {
            hu.force = 2;
        }
    }

    public void SetLoseState()
    {

    }
   
}
