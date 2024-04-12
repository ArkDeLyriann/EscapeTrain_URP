using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SC_Fingerprints : MonoBehaviour
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
}
