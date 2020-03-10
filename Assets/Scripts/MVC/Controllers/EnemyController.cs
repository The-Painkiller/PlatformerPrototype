using UnityEngine;
using System.Collections;

/// <summary>
/// MVC  Controller for Enemy. Extends from CharacterController.
/// Lets enemy simply move left/right and change direction if wall is hit (implemented in View).
/// SetBaseModelView of base class supposed to be called here on Awake.
/// </summary>
public class EnemyController : CharacterController
{
    private EnemyModel _model;
    private EnemyView _view;

    private bool _isMovingRight;

    private void Awake ( )
    {
        _model = new EnemyModel ( 1 );
        _view = GetComponent<EnemyView> ( );

        SetBaseModelView ( _model, _view );
    }

    private void Start ( )
    {
        _view.WallTouched += ( ) => _isMovingRight = !_isMovingRight;
        _view.CharacterKilled += Dead ;
    }

    private void FixedUpdate ( )
    {
        if ( _isMovingRight )
            MoveInDirection ( CharacterMoveDirection.Right );
        else
            MoveInDirection ( CharacterMoveDirection.Left );
    }
}