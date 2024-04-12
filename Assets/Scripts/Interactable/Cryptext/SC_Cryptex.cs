using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_Cryptex : C_Interactable
{
    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    private Rigidbody myselfRigidbody;
    public GameObject panelUP;
    public GameObject panelDOWN;
    public Camera myCam;

    [SerializeField]
    private Vector3 originPos;
    [SerializeField]
    private Quaternion originRot;

    public bool canBeUsed;

    public GameObject crosshair;


    private void Start()
    {
        canBeUsed = true;
        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    void Update()
    {
        if (isPicked)
        {
            myself.transform.position = holdPos.transform.position;
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                PutBack();
            }
            


        }

    }

    //Fonction d'interaction
    public override void Interact()
    {
        if (canBeUsed) { 

        crosshair.SetActive(false);
        panelUP.SetActive(true);
        panelDOWN.SetActive(true);


        fpsController.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pickUpScript.canInteract = false;


        isPicked = true;
        myself.transform.rotation = myCam.transform.rotation;
        myself.transform.Rotate(270, 0, 90);
        myself.transform.parent = holdPos.transform;
        myself.transform.position = holdPos.transform.position;

        
        myselfRigidbody.freezeRotation = true;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);

        }
        else
        {
            print("Already Solved");
        }
    }






    //Fonction pour lâcher l'objet
    public void PutBack()
    {

        crosshair.SetActive(true);

        panelUP.SetActive(false);
        panelDOWN.SetActive(false);

        isPicked = false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        myselfRigidbody.freezeRotation = false;
        fpsController.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myself.transform.position = originPos;
        myself.transform.rotation= originRot;
    }



}
