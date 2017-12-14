using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance 
    {
        get 
        {
            if(_instance == null)
                _instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            if(_instance == null)
                _instance = new GameManager();
            return _instance;
        }
        set 
        {
            if (_instance)
                Destroy(_instance.gameObject);
            _instance = value;
        }
    }
    public PlayerBehaviour player;

    void Start()
    {
        if (!player) player = FindObjectOfType<PlayerBehaviour>();
    }
}
