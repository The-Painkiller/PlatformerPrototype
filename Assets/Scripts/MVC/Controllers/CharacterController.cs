using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

/// <summary>
/// MVC Controller for Base Character.
/// Has basic functionalities to be used by both, Player & enemies.
/// </summary>
public class CharacterController : MonoBehaviour
{
    private CharacterModel _characterModel;
    private CharacterView _characterView;

    private Quaternion _rightRotation = Quaternion.Euler ( 0, 90, 0 );
    private Quaternion _leftRotation = Quaternion.Euler ( 0, -90, 0 );

    /// <summary>
    /// Sets this base class' Model and View properties.
    /// Required for base functions to work.
    /// </summary>
    /// <param name="model">Pass Model class</param>
    /// <param name="view">Pass View class</param>
    public void SetBaseModelView ( CharacterModel model, CharacterView view )
    {
        _characterModel = model;
        _characterView = view;
    }

    /// <summary>
    /// Movement in Left/Right directions
    /// </summary>
    /// <param name="direction">Left/Right</param>
    public void MoveInDirection ( CharacterMoveDirection direction )
    {
        RotateInDirection ( direction );
        if(direction == CharacterMoveDirection.Left)
            _characterView.transform.position += Vector3.left * Time.deltaTime * _characterModel._movementSpeed;
        else
            _characterView.transform.position += Vector3.right * Time.deltaTime * _characterModel._movementSpeed;
    }
    
    /// <summary>
    /// Character orientation in Left/Right directions
    /// </summary>
    /// <param name="direction">Facing Left/Right</param>
    private void RotateInDirection (CharacterMoveDirection direction )
    {
        if ( direction == CharacterMoveDirection.Right )
        {
            if ( _characterView.transform.rotation == _rightRotation )
                return;

            _characterView.transform.rotation = _rightRotation;
        }
        else
        {
            if ( _characterView.transform.rotation == _leftRotation )
                return;

            _characterView.transform.rotation = _leftRotation;
        }
    }

    /// <summary>
    /// Character death.
    /// Basic at this point. Can be extended.
    /// </summary>
    public void Dead ( )
    {
        _characterView.gameObject.SetActive ( false );
        this.enabled = false;
    }
}