using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Computer : C_Interactable
{

    public GameObject ComputerScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        ComputerScreen.SetActive(true);
    }
}
