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
    //private int _layers = 1 << 9;
    public float _range = 5.0f;
    private bool _frozen = false;

    private void Start()
    {
        camcontroller = transform.GetComponent<CameraController>();
        
    }

    void Update()
    {
        if(!_frozen)
            Move();

        CheckObjects();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x * _speed, 0, y * _speed);
        move *= Time.deltaTime;
        transform.Translate(move);
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
            ChangeCursor(_cursorHand, 1);
            if (Input.GetMouseButton(0))
            {
                hit.transform.position = new Vector3(hit.transform.position.x + Input.GetAxis("Mouse X"),hit.transform.position.y,hit.transform.position.z);
            }
        }
        else
        {
            ChangeCursor(_cursorOver,0.5f);
        }
    }

    private void ChangeCursor(Sprite cursor,float scale)
    {
        _cursor.sprite = cursor;
        _cursor.transform.localScale = new Vector3(scale, scale, 1);
        Debug.Log(_cursor.sprite.name);
    }
}
