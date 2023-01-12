using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] private Peg[] CodePegs;    // answers pegs
    [SerializeField] private Peg[] KeyPegs;     // results pegs

    public void ActivateLine()
    {
        for (int i = 0; i < CodePegs.Length; i++)
        {
            CodePegs[i].ActivatePeg();
        }
    }

    public void DesactivateLine()
    {
        for (int i = 0; i < CodePegs.Length; i++)
        {
            CodePegs[i].DesactivatePeg();
        }
    }

    public int[] GetRowColors()
    {
        int[] rowColors = new int[KeyPegs.Length];
        for (int i = 0; i < KeyPegs.Length; i++)
        {
            rowColors[i] = KeyPegs[i].GetColorNumber();
        }
        return rowColors;
    }

    public void ApplyResult(int[] results)
    {
        for (int i = 0; i < KeyPegs.Length; i++)
        {
            KeyPegs[i].ChangeColor(results[i]);
        }
    }
}
