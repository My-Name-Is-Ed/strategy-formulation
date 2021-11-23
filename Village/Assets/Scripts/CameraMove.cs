using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speedCamera = 20;
    public float rangeToMove = 20;

    public float x1 = -17;
    public float x2 = 24;
    public float y1 = -17;
    public float y2 = 24;

    float screenWidth;
    float screenHeight;

    private void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
    private void Update()
    {
        Vector3 camPos = transform.position;

        if ((Input.mousePosition.y >= screenHeight - rangeToMove 
            && Input.mousePosition.x >= screenWidth - rangeToMove) 
            || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)))         //UP RIGHT
        {
            camPos.x += Time.deltaTime * speedCamera;
        }
        else if ((Input.mousePosition.y >= screenHeight - rangeToMove 
            && Input.mousePosition.x <= rangeToMove) 
            || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)))        //UP LEFT
        {
            camPos.z += Time.deltaTime * speedCamera;
        }
        else if ((Input.mousePosition.y <= rangeToMove 
            && Input.mousePosition.x >= screenWidth - rangeToMove) 
            || (Input.GetKey(KeyCode.S) 
            && Input.GetKey(KeyCode.D)))         //DOWN RIGHT
        {
            camPos.z -= Time.deltaTime * speedCamera;
        }
        else if ((Input.mousePosition.y <= rangeToMove 
            && Input.mousePosition.x <= rangeToMove) 
            || (Input.GetKey(KeyCode.S) 
            && Input.GetKey(KeyCode.A)))        //DOWN LEFT
        {
            camPos.x -= Time.deltaTime * speedCamera;
        }
        else if (Input.mousePosition.y >= screenHeight - rangeToMove 
            || Input.GetKey(KeyCode.W))          //UP
        {
            camPos.x += Time.deltaTime * speedCamera;
            camPos.z += Time.deltaTime * speedCamera;
        }
        else if (Input.mousePosition.y <= rangeToMove 
            || Input.GetKey(KeyCode.S))         // DOWN
        {
            camPos.x -= Time.deltaTime * speedCamera;
            camPos.z -= Time.deltaTime * speedCamera;
        }
        else if (Input.mousePosition.x >= screenWidth - rangeToMove 
            || Input.GetKey(KeyCode.D))         //RIGHT
        {
            camPos.x += Time.deltaTime * speedCamera;
            camPos.z -= Time.deltaTime * speedCamera;
        }
        else if (Input.mousePosition.x <= rangeToMove 
            || Input.GetKey(KeyCode.A))         //LEFT
        {
            camPos.x -= Time.deltaTime * speedCamera;
            camPos.z += Time.deltaTime * speedCamera;
        }
        //transform.position = camPos;
        transform.position = new Vector3(Mathf.Clamp(camPos.x, x1, x2), camPos.y, Mathf.Clamp(camPos.z, y1, y2));
    }       
}
