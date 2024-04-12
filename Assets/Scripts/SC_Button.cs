using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Button : MonoBehaviour
{
    
    public string buttonValue;



    public SC_ManagerGlobal alarmManager;

    private void Start()
    {
        alarmManager = FindObjectOfType<SC_ManagerGlobal>();
    }

    public void OnMouseDown()
    {
        Debug.Log("la valeur est de :" +  buttonValue);
        alarmManager.ReceiveValue(buttonValue);
    }
}
