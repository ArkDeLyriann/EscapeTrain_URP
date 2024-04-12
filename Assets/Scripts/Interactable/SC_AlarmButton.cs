using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AlarmButton : MonoBehaviour
{
    public SC_ManagerGlobal alarmManager;

    private void Start()
    {
        alarmManager = FindObjectOfType<SC_ManagerGlobal>();
    }

    public void OnMouseDown()
    {
        Debug.Log("try validation");
    
        alarmManager.CheckValidation();
    }
}


