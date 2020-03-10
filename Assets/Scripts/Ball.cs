using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float throwPower;
    public Rigidbody rb;

    public Vector3 minPower;
    public Vector3 maxPower;

    public bool isDragging = false;

    Camera cam;
    public GameObject playerObject;
    Vector3 ballForce;
    Vector3 dragStartPoint;
    Vector3 dragEndPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            dragStartPoint = (Input.mousePosition);
            Debug.Log(dragStartPoint);
        }

        if (Input.GetMouseButton(0))
        {
            isDragging = true;
            Vector3 currentPoint = (Input.mousePosition);
            Debug.Log(currentPoint);

        }

        if (Input.GetMouseButtonUp(0))
        {
            
            isDragging = false;

            dragEndPoint = (Input.mousePosition);

            ballForce = new Vector3(Mathf.Clamp(dragStartPoint.x - dragEndPoint.x, minPower.x, maxPower.x), Mathf.Clamp(dragStartPoint.y - dragEndPoint.y, minPower.y, maxPower.y),0);

            Debug.Log(dragEndPoint);

            rb.AddForce(ballForce * throwPower, ForceMode.Force);
        }
    }


}
