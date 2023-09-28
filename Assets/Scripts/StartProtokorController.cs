using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StartProtokorController : MonoBehaviour
{
    [SerializeField] private Text _textOfPlayerStarting;
    [SerializeField] private Text _textOfTimeStarting;
    [SerializeField] private InputField _startPromeg;

    private TimeSpan _timeDelay;
    private TimeSpan _timeRemain = new TimeSpan(0);
    private PlayerController _player;


    public bool IsStarting = false;

    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    public void StartOn()
    {
        IsStarting = !IsStarting;
        if(IsStarting == true)
        {
            _timeDelay = new TimeSpan(int.Parse(_startPromeg.text)* 10000000);
            NewPlayerStart();
        }
    }

    void NewPlayerStart()
    {
        
        _timeRemain = new TimeSpan(0);
    }

    public void StepSecond()
    {
        if (!IsStarting) return;
        _timeRemain += new TimeSpan(10000000);
        _textOfTimeStarting.text = (_timeDelay - _timeRemain).Seconds.ToString();
        _player = _gameController.Players[0];
        _textOfPlayerStarting.text = _player.Name;
        if (_textOfTimeStarting.text == "3") GetComponent<AudioSource>().Play();
        if (_textOfTimeStarting.text == "0")
        {
            if (!_player.IsNullTime)
            {
                IsStarting = false;
                return;
            }
            _player.OnStart();
            NewPlayerStart();
            if(_gameController.Players[1].IsNullTime == false) IsStarting = false;

        }
    }
}
