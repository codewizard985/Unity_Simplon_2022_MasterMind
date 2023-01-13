using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] private AppManager appmanager;
    private int ActualColorNumber = -1;
    private Collider Collider;

    private void Start()
    {
        Collider = GetComponent<Collider>();

    }

    public void ActivatePeg()
    {
        Collider.enabled = true;
    }
    public void DesactivatePeg()
    {
        Collider.enabled = false;
    }


    public int GetColorNumber()
    {
        return ActualColorNumber;
    }

    public void ChangeColor()
    {

        if (ActualColorNumber == -1 || ActualColorNumber >= appmanager.CodePegs.Length - 1)
        {
            ActualColorNumber = 0;
        }
        else
        {
            ActualColorNumber++;
        }
        Debug.Log("change color = " + ActualColorNumber);

        GetComponent<MeshRenderer>().material.SetColor("_Color", appmanager.CodePegs[ActualColorNumber]);
    }
    public void ChangeColor(int resultColorNumber)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", appmanager.KeyPegs[resultColorNumber]);
    }
}
