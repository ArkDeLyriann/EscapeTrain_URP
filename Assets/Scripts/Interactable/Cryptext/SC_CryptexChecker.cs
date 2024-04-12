using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CryptexChecker : MonoBehaviour
{
    [SerializeField]
    private SC_CryptexSolver solver;

    private void OnTriggerEnter(Collider other)
    {
        solver.solvedPieces += 1;


    }

    private void OnTriggerExit(Collider other)
    {
        solver.solvedPieces -= 1;
    }
}
