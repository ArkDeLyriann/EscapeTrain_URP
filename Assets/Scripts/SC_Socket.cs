using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Socket : MonoBehaviour
{
    //Yoann
    public GameObject validateLight;
    public Material lightMaterial1;
    public Material lightMaterial2;

    public Vector3 pluggingPosition;
    public string colorToDetect;

    
    //Modify the Material of the light
    public void ChangelightMaterial(Material newMaterial)
    {
        Renderer lighRenderer = validateLight.GetComponent<Renderer>();
        lighRenderer.material = newMaterial;
    }

    /*Detect the collosion of the cable if the tag is good lock the position
     else start the fuction returning the object at his initial position*/
    /*void OnCollisionEnter(Collision collision)
    {
        SC_Cable cableScript = collision.gameObject.GetComponent<SC_Cable>();
        if (cableScript != null && cableScript.GetTagObjectCollider() == colorToDetect)
        {
            Debug.Log("Good Color");
            ChangelightMaterial(lightMaterial2);
            ModifyPosition(cableScript.gameObject);
        }
        else if (cableScript != null)
        {
            Debug.Log("wrong color");
            cableScript.ReturnToInitialPosition();
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        SC_Cable cableScript = other.gameObject.GetComponent<SC_Cable>();
        if (cableScript != null && cableScript.GetTagObjectCollider() == colorToDetect)
        {
            Debug.Log("Good Color");
            ChangelightMaterial(lightMaterial2);
            ModifyPosition(cableScript.gameObject);
        }
        else if (cableScript != null)
        {
            Debug.Log("wrong color");
            cableScript.ReturnToInitialPosition();
        }
    }

    // change the position of the cable
    public void ModifyPosition(GameObject objToMove)
    {
        Vector3 newPosition = new Vector3(pluggingPosition.x, objToMove.transform.position.y, objToMove.transform.position.z);
        objToMove.transform.position = newPosition;
    }
}
