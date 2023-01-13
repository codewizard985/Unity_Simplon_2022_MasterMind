using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Board : MonoBehaviour
{
    //UnityEvent = constructor => we declare the event
    public UnityEvent OnWin;
    /**
     * C# version of delegate.
     * A delegate is a type that safely encapsulates a method.
     * Delegates are object-oriented, type safe, and secure.
     * The type of a delegate is defined by the name of the delegate. 
     *  **/
    public delegate void MessageEvent();
    public static event MessageEvent OnLoose;   // Create a method for a delegate.
    [SerializeField] private Row[] rows;
    [SerializeField] private Peg[] secretRowPegs;
    [SerializeField] private AppManager appmanager;
    [SerializeField] private int[] SecretRow;
    private int ActualLine = 0;

    void Start()
    {
        SetSecretRow();
        ActivateNewLine();
    }


    private void SetSecretRow()
    {
        SecretRow = new int[4];
        for (int i = 0; i < SecretRow.Length; i++)
        {
            SecretRow[i] = Random.Range(0, appmanager.CodePegs.Length);
            secretRowPegs[i].gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", appmanager.CodePegs[SecretRow[i]]);
        }
    }

    private void ActivateNewLine()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            if (i == ActualLine)
            {
                rows[i].ActivateLine();
            }
            else
            {
                rows[i].DesactivateLine();
            }
        }
    }

    public void CheckActualRow()
    {
        int[] answer = rows[ActualLine].GetRowColors();
        for (int i = 0; i < answer.Length; i++)
        {
            if (answer[i] == -1)
            {
                return;
            }
        }

    }
}
