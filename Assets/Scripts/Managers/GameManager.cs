using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager class.
/// At this point only handles Player and Display Manager.
/// Later It can be extended to dynamically spawn player and enemies, have more rules in the game, etc.
/// </summary>
public class GameManager : MonoBehaviour
{
    public PlayerController _player;
    public DisplayManager _displayManager;
    public PlayerInputControl _inputControl;

    private void Awake ( )
    {
        _inputControl.LeftButton += MovePlayerLeft;
        _inputControl.RightButton += MovePlayerRight;
        _inputControl.Shoot += PlayerShoot;
        _inputControl.Jump += PlayerJump;

        _displayManager.RestartPressed += RestartLevel;
        _player.CastleTouched += ( ) => { DisplayPlayerResult ( true ); };
        _player.PlayerDead += ( ) => { DisplayPlayerResult ( false ); };
        _player.ScoreIncreased +=   DisplayScore;
    }

    private void PlayerJump ( )
    {
        _player.Jump ( );
    }

    private void PlayerShoot ( )
    {
        _player.Shoot ( );
    }

    private void DisplayPlayerResult ( bool win)
    {
        _displayManager.DisplayResult ( win );
    }

    private void DisplayScore ( int score )
    {
        _displayManager.UpdateScore ( score );
    }

    private void RestartLevel ( )
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene ( 0 );
    }

    private void MovePlayerLeft ( bool isPressed )
    {
        _player.MoveLeft ( isPressed );
    }

    private void MovePlayerRight ( bool isPressed )
    {
        _player.MoveRight ( isPressed );
    }
}
