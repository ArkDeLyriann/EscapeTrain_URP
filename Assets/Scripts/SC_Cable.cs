using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SC_Cable : C_Interactable
{
    //Yoann

    public bool isPicked;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    public float smoothSpeed;
    public string tagObjectCollider;


    private Vector3 initialPosition;

    private Rigidbody myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isPicked)
        {
            MoveObjectWithMouse();

            if (Input.GetKeyDown(KeyCode.E))
            {
                ReleaseObject();
            }
        }
        else
        {
            if (IsObjectInCenter() && Input.GetKeyDown(KeyCode.E))
            {
                //pickUpScript.PickUpObject(gameObject);
            }
        }
    }

    void MoveObjectWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Vector3.Distance(Camera.main.transform.position, transform.position);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 newPosition = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
    }

    void PickUpObject()
    {
        isPicked = true;
        initialPosition = transform.position;

        myRigidBody.isKinematic = true;
        myRigidBody.detectCollisions = false;
    }

    public void ReleaseObject()
    {
        isPicked = false;
        transform.position = initialPosition;

        myRigidBody.isKinematic = false;
        myRigidBody.detectCollisions = true;
    }

    bool IsObjectInCenter()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }

    public string GetTagObjectCollider()
    {
        return tagObjectCollider;
    }

    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    public void ReturnToInitialPosition()
    {
        gameObject.transform.position = initialPosition;
    }
}

