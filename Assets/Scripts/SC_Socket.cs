using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Socket : MonoBehaviour
{

    public GameObject light;
    public Material lightMaterial1;
    public Material lightMaterial2;

    public Vector3 pluggingPosition;
    public string colorToDetect;

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangelightMaterial(Material newMaterial)
    {
        Renderer lighRenderer = light.GetComponent<Renderer>();
        Debug.Assert(lighRenderer != null, "Le composant Renderer n'est pas attaché à l'objet de lumière.");
        lighRenderer.material = newMaterial;
    }

    void OnCollisionEnter(Collision collision)
    {
        SC_Cable cableScript = collision.gameObject.GetComponent<SC_Cable>();
        if (cableScript != null && cableScript.GetTagObjectCollider() == colorToDetect)
        {
            ChangelightMaterial(lightMaterial2);
            ModifyPosition(cableScript.gameObject);
        }
        else if (cableScript != null)
        {
            cableScript.ReturnToInitialPosition();
        }
    }

    public void ModifyPosition(GameObject objToMove)
    {
        Vector3 newPosition = new Vector3(pluggingPosition.x, objToMove.transform.position.y, objToMove.transform.position.z);
        objToMove.transform.position = newPosition;
    }
}
