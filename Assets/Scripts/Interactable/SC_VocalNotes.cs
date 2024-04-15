using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_VocalNotes : C_Interactable
{
    //Hugo
    public AudioSource mySource;

    public override void Interact()
    {
        mySource.Play();
    }
    
}
