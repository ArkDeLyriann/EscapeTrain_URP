using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_WireConnection : MonoBehaviour
{
    public string targetTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Debug.Log("Good link");
        }
        else
        {
            Debug.Log("wrong");
        }


    }
}
