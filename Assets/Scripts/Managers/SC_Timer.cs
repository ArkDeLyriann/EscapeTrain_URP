using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject moon, earth;

    [SerializeField]
    private Vector2 maxEarth, minEarth, maxMoon, minMoon;

    private float lerp;

    public float time;
    
    
    void Start()
    {

        // On set les images a leurs tailles du début
        earth.transform.localScale= maxEarth; 
        
        moon.transform.localScale = minMoon;


    }

    
    void Update()
    {
        time += Time.deltaTime;  // Variable de temps si nécéssaire pour events scriptés

        lerp += Time.deltaTime/60; // on trouve une valeur entre 0 et 1 pour nos lerp (le nombre est la durée souhaitée du temps de jeu en secondes)

        earth.transform.localScale = Vector2.Lerp(maxEarth, minEarth, lerp); //On fait passer la Terre de sa taille max a sa taille min en fct du temps


        moon.transform.localScale = Vector3.Lerp(minMoon,maxMoon, lerp); // Inverse pour la lune


    }
}
