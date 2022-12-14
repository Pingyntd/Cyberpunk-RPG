using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed;
    public int test;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.DownArrow)){
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
