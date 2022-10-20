using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _penguinPrefab;

    public int PenguinCount;
    void Start()
    {
        spawnPengys();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPengys()
    {

        for (int i = 0; i < PenguinCount; i++)
        {
            Instantiate(_penguinPrefab, new Vector3(4.5f, 5f, 0), Quaternion.identity, this.transform);

        }
    }
}
