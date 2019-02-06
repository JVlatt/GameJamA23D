using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool _controlled = false;
    private GameObject _player;
    public Transform _light;
    float anglex = 0;
    float angley = 0;
    float speed = 90;

    void Update()
    {
        if (_controlled)
        { 
            Move();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x != 0)
        { 
            anglex += Mathf.Sign(x) * speed * Time.deltaTime;
        }
        if(y != 0)
        {
            angley += Mathf.Sign(y) * speed * Time.deltaTime;
        }
        _light.rotation = Quaternion.Euler(anglex, angley, 0);

    }
    public void Control(GameObject player)
    {
        _player = player;
        _controlled = true;
    }
    private void Exit()
    {
        //_player.GetComponent<>
        _controlled = false;
    }



}
