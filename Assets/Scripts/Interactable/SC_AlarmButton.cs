using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AlarmButton : MonoBehaviour
{
    public SC_ManagerGlobal alarmManager;
    public int puzzle;
    public List<string> codeToCompare;
    private void Start()
    {
        alarmManager = FindObjectOfType<SC_ManagerGlobal>();
    }

    public void OnMouseDown()
    {
        Debug.Log("try validation");
    
        alarmManager.CheckValidation(codeToCompare,puzzle);
    }
}


