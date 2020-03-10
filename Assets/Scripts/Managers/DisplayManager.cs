using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Display Manager for score and win/lose screens.
/// This can be extended to show more UI later.
/// Win/Lose screens at this point are very basic. Can be bettered.
/// </summary>
public class DisplayManager : MonoBehaviour
{
    public Text _scoreText;
    public GameObject _gameWinScreen;
    public GameObject _gameLoseScreen;

    public Action RestartPressed { get; set; }

    public void UpdateScore ( int score)
    {
        _scoreText.text = score.ToString ("000");
    }

    /// <summary>
    /// Called from OnClick of Restart buttons in win/lose screens.
    /// </summary>
    public void RestartLevel ( )
    {
        RestartPressed.Invoke ( );
    }

    public void DisplayResult ( bool win )
    {
        if ( win )
            _gameWinScreen.SetActive ( true );
        else
            _gameLoseScreen.SetActive ( true );
    }
}
