using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseKeys : MonoBehaviour
{
    public float timer;
    private TextMeshProUGUI Text;
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 2.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
