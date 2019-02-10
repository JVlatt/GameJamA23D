using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image _cursor;

    public Sprite _cursorHand;
    public Sprite _cursorOver;

    public float _speed = 10.0f;
    private CameraController camcontroller;
    public float _range = 5.0f;
    public bool _frozen = true;
    private float _timer = 0.5f;
    public bool gamejam;
    private float _tActive = 0.0f;
    private float _tWait = 7.0f;

    private void Start()
    {
        camcontroller = transform.GetComponent<CameraController>();
        if (!gamejam)
        {
            VoixManager.voixManager.Playvoice();
            gamejam = true;
        }
    }

    void Update()
    {
        if(!_frozen)
        {
            Move();
            CheckObjects();
        }

        _tActive += Time.deltaTime;
        if (_tActive > _tWait)
        {
            _frozen = false;
            return;
        }

    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x * _speed, 0, y * _speed);
        move *= Time.deltaTime;
        transform.Translate(move);
        _timer -= Time.deltaTime;
        if ((x >= 0.1f || x <= -0.1f || y >= 0.1f || y <= -0.1f) && _timer <= 0)
        {
            SoundControler._soundControler.FootStep();
            _timer = 0.5f;
        }

    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Lamp")
        { 
            camcontroller.Block(true);
            _frozen = true;
            other.gameObject.GetComponent<Lamp>().Control(gameObject);
        }
    }
    
    private void CheckObjects()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _range) && hit.transform.tag == "InteractiveObject")
        {
            ChangeCursor(_cursorHand, 0.5f);
            if (Input.GetMouseButton(0))
            {
                hit.transform.position = new Vector3(hit.transform.position.x,hit.transform.position.y,hit.transform.position.z - Input.GetAxis("Mouse X"));
            }
        }
        else
        {
            ChangeCursor(_cursorOver,0.2f);
        }
    }

    private void ChangeCursor(Sprite cursor,float scale)
    {
        _cursor.sprite = cursor;
        _cursor.transform.localScale = new Vector3(scale, scale, 1);
        Debug.Log(_cursor.sprite.name);
    }
}
