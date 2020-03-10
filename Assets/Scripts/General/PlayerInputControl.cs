using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Input control for player.
/// This can be easily extended and applied to any input binding.
/// </summary>
public class PlayerInputControl : MonoBehaviour
{
    public Action<bool> LeftButton;
    public Action<bool> RightButton;
    public Action Shoot;
    public Action Jump;

    public void OnLeftButton ( bool isPressed)
    {
        LeftButton.Invoke ( isPressed );
    }

    public void OnRightButton ( bool isPressed )
    {
        RightButton.Invoke ( isPressed );
    }

    public void OnJump ( )
    {
        Jump.Invoke ( );
    }

    public void OnShoot ( )
    {
        Shoot.Invoke ( );
    }

#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE
    private void Update ( )
    {
        if ( Input.GetKeyDown ( KeyCode.D ) )
            OnRightButton ( true );
        else if ( Input.GetKeyDown ( KeyCode.A ) )
            OnLeftButton ( true );

        if ( Input.GetKeyUp ( KeyCode.D ) )
            OnRightButton ( false );
        else if ( Input.GetKeyUp ( KeyCode.A ) )
            OnLeftButton ( false );

        if ( Input.GetKeyDown ( KeyCode.Space ) )
            OnJump ( );

        if ( Input.GetKeyDown ( KeyCode.E ) )
            OnShoot ( );
    }
#endif
}