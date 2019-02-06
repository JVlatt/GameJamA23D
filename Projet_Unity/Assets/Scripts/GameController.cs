using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController _gameController;
    private Transform _player;
    private Transform _camera;
    private PlayerController _playerController;
    private CameraController _cameraController;


    private void Awake()
    {
        _gameController = this;
        _player = Camera.main.transform.parent;
        _camera = Camera.main.transform;
        _playerController = _player.GetComponent<PlayerController>();
        _cameraController = _camera.GetComponent<CameraController>();
    }

    public void Freeze(bool state)
    { 
        _playerController._frozen = state;
        _cameraController.Block(state);    
    }
}
