using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _winMessage;
    [SerializeField] private GameObject _looseMessage;
    //Variable qui permettra d'acceder à l'event version Unity
    [SerializeField] private Board _board;

    private void OnEnable()
    {
        // UnityEvent: We register the WinMessage function at the OnWin event.
        // We absolutely need access to the _board object instantiated from the Board class
        _board.OnWin.AddListener(WinMessage);

        // C#: register the LooseMessage function at the OnLoose event.
        // Thanks to the static property we just have to find the Board class
        Board.OnLoose += LooseMessage;
    }
    private void OnDisable()
    {
        // In both cases we unsubscribe from the event
        _board.OnWin.RemoveListener(WinMessage);
        Board.OnLoose -= LooseMessage;

    }
    private void WinMessage()
    {
        _winMessage.SetActive(true);
    }
    private void LooseMessage()
    {
        _looseMessage.SetActive(true);

    }
}
