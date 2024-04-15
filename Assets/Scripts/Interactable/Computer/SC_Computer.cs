using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Computer : C_Interactable
{
    //Hugo
    public GameObject crosshair;
    public GameObject ComputerScreen;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    public bool isPicked;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<SC_FPSController>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                QuitComputer();
            }
        }
    }

    public override void Interact()
    {
        crosshair.SetActive(false);

        fpsController.canMove = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ComputerScreen.SetActive(true);
        isPicked = true;


    }

    public void QuitComputer()
    {
        isPicked = false;

        crosshair.SetActive(true);

        fpsController.canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ComputerScreen.SetActive(false);
        pickUpScript.canInteract = true;

        
    }
}
