using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class NameComparer : IComparer<PlayerController>
{
    public int Compare(PlayerController o1, PlayerController o2)
    {
        if (o1.Result > o2.Result)
        {
            return 1;
        }
        else if (o1.Result < o2.Result)
        {
            return -1;
        }

        return 0;
    }
}

public class GameController : MonoBehaviour
{

    [SerializeField] private Color _finishColor;
    [SerializeField] private Image _imageFinish;
    private StartProtokorController _startProtokorController;

    private Color _normalColor;
    private NameComparer _nameComparer = new NameComparer();

    public Text FinishChet;
    public DateTime NowTime;
    public List<DateTime> FinishTime = new List<DateTime>();

    public List<PlayerController> Players = new List<PlayerController>();
    
    private bool _isFinished { get; set; }
    public bool IsFinished
    {
        get
        {
            return _isFinished;
        }
        set
        {
            _isFinished = value;
            if(value == false)
            {
                _imageFinish.color = _normalColor;
                FinishTime.Clear();
                FinishChet.text = FinishTime.Count.ToString();
            }
            
        }
    }

    public void PlayerToId(int id, PlayerController player)
    {
        int oldId = Players.IndexOf(player);

        PlayerController tempObj = Players[oldId];
        Players[oldId] = Players[id];
        Players[id] = tempObj;
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].transform.SetSiblingIndex(i);
        }
    }

    void Awake()
    {
        _startProtokorController = FindObjectOfType<StartProtokorController>();
        StartCoroutine(Wait());
        _normalColor = _imageFinish.color;
    }

    public void OnFinish()
    {
        IsFinished = true;
        if (_imageFinish.color == _normalColor)
            _imageFinish.color = _finishColor;
        else
            _imageFinish.color += new Color(0.1f,0.1f,0.1f);

        FinishTime.Add(NowTime);
        FinishChet.text = FinishTime.Count.ToString();
    }

    void SortPlayer()
    {
        Players.Sort(_nameComparer);
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].transform.SetSiblingIndex(i);
        }
    }
    
    IEnumerator Wait()
    {
        while (true)
        {
            NowTime = DateTime.Now;

            foreach (var item in Players)
            {
                item.Wait();
            }

            SortPlayer();

            _startProtokorController.StepSecond();


            yield return new WaitForSeconds(1);
        }
    }
}
