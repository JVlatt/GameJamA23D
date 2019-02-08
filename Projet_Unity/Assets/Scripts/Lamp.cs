using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool _controlled = false;
    private GameObject _player;
    public GameObject _light;
    public GameObject _target;

    private float _timer;
    private float _cooldown = 1.0f;

    private bool _timerSetup;
    private bool musicplayed;

    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        if (_controlled)
        {
            if (!musicplayed) {
                SoundControler._soundControler.PlaySound(SoundControler._soundControler._lightOn);
                musicplayed = true;
            }
            if(!_timerSetup)
            { 
                _timer = _cooldown;
                _timerSetup = true;
            }

            _light.transform.LookAt(_target.transform);
            Move();
            if (Input.GetKeyUp(KeyCode.E) && _timer <= 0)
                Exit();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0);
        _target.transform.Translate(move);

    }
    public void Control(GameObject player)
    {
        _player = player;
        _controlled = true;
    }
    public void Exit()
    {
        _timerSetup = false;
        _controlled = false;
        _player.GetComponent<PlayerController>()._frozen = false;
        _player.GetComponent<CameraController>().Block(false);
    }



}
