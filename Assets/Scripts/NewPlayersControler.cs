using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewPlayersControler : MonoBehaviour
{
    [SerializeField] private InputField _newPlayer;
    private GameController _gameController;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _content;
    public void OnNewPlayer()
    {
        if (_newPlayer.text == "") return;
        PlayerController player = Instantiate(_playerPrefab, new Vector2(), new Quaternion(), _content).GetComponent<PlayerController>();
        player.Name = _newPlayer.text;
        _gameController.Players.Add(player);
        _newPlayer.text = "";
    }
    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }
}
