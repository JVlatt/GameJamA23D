﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController _gameController;
    private Transform _player;
    private Transform _camera;
    private PlayerController _playerController;
    private CameraController _cameraController;
    public GameObject MenuUI;

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
        _playerController._cursor.gameObject.SetActive(!state);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuUI.activeInHierarchy)
        {
            Freeze(true);
            MenuUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && MenuUI.activeInHierarchy)
        {
            Freeze(false);
            MenuUI.SetActive(false);
        }
    }
}
