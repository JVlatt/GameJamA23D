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
    public LayerMask _interactiveItems;
    public float _range = 5.0f;

    private void Start()
    {
        camcontroller = transform.GetComponent<CameraController>();
        
    }

    void Update()
    {
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
    /*
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0)) camcontroller.Block(true);
        Debug.Log("trigger");
        if (Input.GetKeyDown("e")) camcontroller.Block(false);
    }
    */
    private void CheckObjects()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _range, _interactiveItems))
        {
            ChangeCursor(_cursorHand,5);
            Debug.Log("Change to hand");
        }
        else
        {
            ChangeCursor(_cursorOver,1);
            Debug.Log("Change to dot");
        }
    }

    private void ChangeCursor(Sprite cursor,float scale)
    {
        _cursor.sprite = cursor;
        _cursor.transform.localScale = new Vector3(scale, scale, 1);
        Debug.Log(_cursor.sprite.name);
    }
}
