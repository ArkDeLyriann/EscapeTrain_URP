using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_ComputerButtons : MonoBehaviour
{
    public TextMeshProUGUI deviationText;

    
    public GameObject mainPage;
    public GameObject commsPage;
    public GameObject dataPage;
    public GameObject ventPage;
    public GameObject trajPage;
    public GameObject lightsPage;

  

    public void SetDeviation()
    {
        deviationText.text = "TRAJET DÉVIÉ VERS MARS";
    }

    public void GoToPage(GameObject page)
    {
        
        commsPage.SetActive(false);
        dataPage.SetActive(false);
        ventPage.SetActive(false);
        trajPage.SetActive(false);
        lightsPage.SetActive(false);
        

        page.SetActive(true);


    }

    public void ReturnToMenu()
    {
        commsPage.SetActive(false);
        dataPage.SetActive(false);
        ventPage.SetActive(false);
        trajPage.SetActive(false);
        lightsPage.SetActive(false);
    }


}
