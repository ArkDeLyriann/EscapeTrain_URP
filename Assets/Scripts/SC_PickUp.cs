using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PickUp : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    
     
    public float pickUpRange = 5f; 
     
    private GameObject heldObj; 
    private C_Interactable heldObjInteract;


    public bool canInteract;
    
    void Start()
    {
       
        canInteract = true;
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {  
            if (canInteract) { 
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))   //On trouve l'objet a coup de raycast
                {
                    
                    if (hit.transform.gameObject.tag == "canPickUp")  //Est-ce un objet interactible ?
                    {
                        
                        PickUpObject(hit.transform.gameObject);  
                    }
                }

            }
        }
        
    }

    //On intéragis avec l'objet
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<C_Interactable>()) 
        {
            canInteract = false;
            heldObj = pickUpObj; 
            heldObjInteract = pickUpObj.GetComponent<C_Interactable>();
            heldObjInteract.Interact(); 
        }
    }


    
    

    
    

   
    
}