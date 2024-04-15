using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ManagerGlobal : MonoBehaviour
{
    
    public GameObject chestDoor;
    public GameObject jacuzzi;
    public AudioSource alarm;
    public GameObject officeDoor;

    public List<string> ClickedObjectValue = new List<string>();

    [SerializeField]
    private List<string> AlarmCode = new List<string>();

    private string codeString;
    private int count;





    //Yoann
    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = Random.Range(1, 9);
            codeString = randomNumber.ToString();
            AlarmCode[i] = codeString;
            Debug.Log("le chiffre a trouver est :" + AlarmCode[i]);
        }
        print("le code a trouver est " + AlarmCode[0] + AlarmCode[1] + AlarmCode[2] + AlarmCode[3]);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Yoann
    public void ReceiveValue(string receivedValue)
    {
        ClickedObjectValue.Add(receivedValue);

        Debug.Log(ClickedObjectValue[0]);
        Debug.Log(ClickedObjectValue[1]);
        Debug.Log(ClickedObjectValue[2]);
        Debug.Log(ClickedObjectValue[3]);
    }

    //Yoann
    public void StartAlarm()
    {
        alarm.Play();
    }
    //Yoann
    public void StopAlarm()
    {
        alarm.Stop();
    }

    //Yoann (retravaillé par Hugo)
    public void CheckValidation(List<string> codeToCompare, int puzzle)
    {
        for (int i = 0; i < ClickedObjectValue.Count; i++)
        {

            if (ClickedObjectValue[i] == codeToCompare[i])
            {
                Debug.Log("is good");
                count++;
            }
            else {
                
                StartAlarm();
                return;
            }
        }
        if (count == codeToCompare.Count)
        {
            if(puzzle == 0)
            {
                StopAlarm();
            }
            if(puzzle == 1)
            {
                OpenOffice();
            }
            if (puzzle == 2)
            {
                CheckJacuzzi();
            }
            if(puzzle == 3)
            {
                OpenSecretRoom();
            }
            if(puzzle == 4)
            {
                OpenChest();
            }
            else
            {
                Debug.Log("puzzle inconnu");
                return;
            }
        }
    }

    
    //Hugo
    public void CheckJacuzzi()
    {
        StartCoroutine(JacuzziFlip());
    }
    //Hugo
    public void OpenSecretRoom()
    {

    }

    public void OpenChest()
    {
        chestDoor.SetActive(false);
    }
    public void OpenOffice() 
    {
        officeDoor.SetActive(false);
    }


    IEnumerator JacuzziFlip()
    {
        Vector3 from = new Vector3(-90, 0, 0);
        Vector3 to = new Vector3(90, 0, 0);
        float counter = 0;
        while (counter < 5)
        {
            counter += Time.deltaTime;
            jacuzzi.transform.localEulerAngles = Vector3.Lerp(from, to, (counter / 5));
            yield return null;
        }

        yield return null;
    }
}
