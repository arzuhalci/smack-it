using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;

    private static SpawnManager _instance;


    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("SpawnManager");
                go.AddComponent<SpawnManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(GameManager.Instance.klonlar.Count < 1)
        {
            Instantiate(prefab, new Vector3(0, 0, 20), Quaternion.identity);
        }
    }

}
