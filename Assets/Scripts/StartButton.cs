using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{

    private Button _startButton;

    private void Awake()
    {
        _startButton = GetComponent<Button>();

    }
    void Start()
    {
        
         
        if (_startButton != null)
        {
            _startButton.onClick.AddListener(() => ButtonClicked());

        }
    }

    private void ButtonClicked()
    {

        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

    }

}
