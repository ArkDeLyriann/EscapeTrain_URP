using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SC_Fingerprints : C_Interactable
{

    public DecalProjector projector;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        projector.fadeFactor = 1;

    }

    private void OnTriggerExit(Collider other)
    {
        projector.fadeFactor = 0;
    }


    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public float throwForce = 500f;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    private bool rotating;
    public Camera myCam;


    [SerializeField]
    private float angleX, angleY, angleZ;


    private Rigidbody myselfRigidbody;






    private void Start()
    {

        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    void Update()
    {
        if (isPicked)
        {
            myself.transform.position = holdPos.transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                DropObject();




            }
            RotateObject();

        }

    }

    //Fonction d'interaction
    public override void Interact()
    {
        isPicked = true;
        //myselfRigidbody.isKinematic = true;
        myself.transform.rotation = myCam.transform.rotation;
        myself.transform.Rotate(0, 180, 0);
        myself.transform.parent = holdPos.transform;
        myself.transform.position = holdPos.transform.position;


        myselfRigidbody.freezeRotation = true;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);



    }






    //Fonction pour lâcher l'objet
    void DropObject()
    {
        isPicked = false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        myselfRigidbody.freezeRotation = false;
    }




    //Fonction pour rotate l'objet dans les mains (WIP)
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            fpsController.canMove = false;


            StartCoroutine(rotateObject(myself, Vector3.up * 90, 1));

        }
        else
        {
            fpsController.canMove = true;
        }

    }


    IEnumerator rotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Vector3 newRot = gameObjectToMove.transform.localEulerAngles + eulerAngles;

        Vector3 currentRot = gameObjectToMove.transform.localEulerAngles;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.localEulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
}


