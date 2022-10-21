using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _penguinPrefab;

    public int PenguinCount;
    void Awake()
    {
        spawnPengys();
    }

    public void spawnPengys()
    {

        for (int i = 0; i < PenguinCount; i++)
        {
            Instantiate(_penguinPrefab, new Vector3(3.5f,6f, 0), Quaternion.identity, this.transform);

        }
    }
}
