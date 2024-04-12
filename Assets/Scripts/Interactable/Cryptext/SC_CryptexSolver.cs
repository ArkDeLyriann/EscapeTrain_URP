using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CryptexSolver : MonoBehaviour
{
    private int neededToSolve = 7;
    public int solvedPieces;
    public SC_Cryptex cryptex;

    private void Update()
    {
        if(solvedPieces == neededToSolve) 
        {
            cryptex.PutBack();
            cryptex.canBeUsed = false;
        }
    }
}
