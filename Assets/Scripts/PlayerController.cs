using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool IsStart = false;
    public bool IsNullTime = true;
    public DateTime StartTime;
    public TimeSpan Result = new TimeSpan(0);
    private GameController _gameController;
    [SerializeField] private Text _timeText;
    [SerializeField] private Image _imageButton;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _afterFinishColor;
    [SerializeField] private Text _nameText;
    private Color _normalColor;

    private string _name;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            _nameText.text = value;
        }
    }

    public void OnClick()
    {

        if (_gameController.IsFinished)
        {
            if (IsStart)
            {
                OnFinish(_gameController.FinishTime[0], StartTime);
                _gameController.FinishTime.RemoveAt(0);
                _gameController.FinishChet.text = _gameController.FinishTime.Count.ToString();
                if (_gameController.FinishTime.Count == 0)
                    _gameController.IsFinished = false;
            }
            else _gameController.IsFinished = false;


            return;
        }

        if (IsStart == false)
        {
            OnStart();
            return;
        }
        else
            OnFinish(_gameController.NowTime, StartTime);

    }

    public void Clear()
    {
        IsStart = false;
        IsNullTime = true;
        Result = new TimeSpan(0);
        StartTime = new DateTime();
        _imageButton.color = _normalColor;
        _timeText.text = "Time";
    }

    public void OnStart()
    {
        Result = new TimeSpan();
        StartTime = _gameController.NowTime;
        _imageButton.color = _activeColor;
        IsStart = true;
        IsNullTime = false;
        //transform.SetAsLastSibling();
        
    }


    void OnFinish(DateTime d1, DateTime d2)
    {
        Result = (d1 - d2).Duration();
        _imageButton.color = _afterFinishColor;
        IsStart = false;
        _timeText.text = Result.ToString("hh':'mm':'ss");
    }


    public void Destoroy()
    {
        _gameController.Players.Remove(this);
        Destroy(gameObject);
    }


    private void Awake()
    {
        transform.SetAsFirstSibling();
        _gameController = FindObjectOfType<GameController>();
        _normalColor = _imageButton.color;

        if (_nameText.text != "")
        {
            _name = _nameText.text;
            _gameController.Players.Add(this);
        }
            
    }

    void SetSilbing()
    {
        //int id = transform.GetSiblingIndex();

    }

    public void UpAtSibling()
    {
        int id = _gameController.Players.IndexOf(this);
        if (this.IsNullTime == false) return;
        if (id - 1 < 0) return;
        _gameController.PlayerToId(id - 1, this);
    }
    public void DownAtSibling()
    {
        int id = _gameController.Players.IndexOf(this);
        if (this.IsNullTime == false) return;
        if (id+1 >= _gameController.Players.Count || _gameController.Players[id+1].IsNullTime == false) return;
        _gameController.PlayerToId(id + 1, this);
    }
    public void Wait()
    {
        if (IsStart)
        {
            Result = (_gameController.NowTime - StartTime).Duration();
            _timeText.text = Result.ToString("hh':'mm':'ss");
        }
    }
}
