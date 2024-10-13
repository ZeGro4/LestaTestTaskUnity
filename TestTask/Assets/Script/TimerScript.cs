using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    private float time_game;
    private bool _isStart;
    [SerializeField] Text _text;
    
    public float Time_game
    {
        set { value = time_game; }
        get { return time_game; }
    }

    void Start()
    {
        StartGame();
    }


    public void StartGame()
    {
        _isStart = true;
    }
    public void StoptGame()
    {
        _isStart = false;
    }

    void Update()
    {


        if (_isStart)
        {
            time_game += Time.deltaTime;
            _text.text = time_game.ToString("00");
        }


    }
}
