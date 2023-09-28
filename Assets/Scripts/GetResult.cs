using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetResult : MonoBehaviour
{
    private GameController _gameController;

    void Start()
    {
        
    }
    public void OnGetResult()
    {
        int number = 1;
        string resultList = $"{DateTime.Today.Day}.{DateTime.Today.Month}.{DateTime.Today.Year}\n\n";
        string noStartList = "\nНе финишировавшие:\n\n";

        foreach (var player in _gameController.Players)
        {

            if(player.IsNullTime == false && !player.IsStart)
            {
                resultList += $"{number}. {player.Name} " +
                    $"     {player.Result.ToString("hh':'mm':'ss")}\n";

                number++;
            }
            else
            {
                string finishTime = "";

                if (player.Result.Ticks != 0)
                {
                    finishTime += $"     {player.Result.ToString("hh':'mm':'ss")}++";
                }

                noStartList += $"{player.Name}{finishTime}\n";
            }
        }

        resultList += noStartList;
        print(resultList);
        TextEditor te = new TextEditor();
        te.text = resultList;
        te.SelectAll();
        te.Copy();
        ClearResult();
    }
    void ClearResult()
    {
        foreach (var player in _gameController.Players)
        {
            player.Clear();
        }
    }

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }
}
