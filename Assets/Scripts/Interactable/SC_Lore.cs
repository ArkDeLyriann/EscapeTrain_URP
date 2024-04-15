using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class SC_Lore : C_Interactable
{
    public GameObject Lore;
    public bool isPicked;
    public GameObject crosshair;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;


    private void Start()
    {
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }


    void Update()
    {
        if (isPicked)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                QuitLore();
            }
        }
    }


    public override void Interact()
    {
        crosshair.SetActive(false);

        fpsController.canMove = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;



        isPicked = true;
        Lore.SetActive(true);
    }

    public void QuitLore()
    {
        crosshair.SetActive(true);

        fpsController.canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pickUpScript.canInteract = true;

        Lore.SetActive(false);
    }
}
