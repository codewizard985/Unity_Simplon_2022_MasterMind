using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField] SecretCode secretcode;
    [SerializeField] private Color[] CodePegs;
    [SerializeField] private Color[] KeyPegs;

    void Start()
    {
        // Recover the secret code in the variable
        secretcode.GetNewSecretCode();
        Debug.Log("The secret code is ");

        foreach (var item in secretcode.secretCode)
        {
            Debug.Log(item);
        }
    }
}
