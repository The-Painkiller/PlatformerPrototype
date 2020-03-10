using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

/// <summary>
/// MVC Controller for Player.
/// Movement, jump and shoot through input control handled here.
/// Score also handled here.
/// Player win/lose sent to GameManager to handle.
/// </summary>
public class PlayerController : CharacterController
{
    public Action CastleTouched;
    public Action PlayerDead;
    public Action<int> ScoreIncreased;

    private PlayerView _view;
    private PlayerModel _model;

    private bool _movingRight;
    private bool _movingLeft;
    private bool _isJumping;

    private void Awake ( )
    {
        _model = new PlayerModel ( 3f, 10f, 9f );
        _view = GetComponent<PlayerView> ( );

        InitializeProjectilePool ( _view._projectilePrefab, 20 );

        SetBaseModelView ( _model, _view );
    }

    private void Start ( )
    {
        _view.CharacterKilled +=  PlayerDeath;
        _view.CastleTouched +=  () => CastleTouched.Invoke() ;
        _view.CoinCollected += IncrementScore ;
    }

    private void FixedUpdate ( )
    {
        if ( _movingRight )
        {
            MoveInDirection ( CharacterMoveDirection.Right );
        }
        else if ( _movingLeft )
        {
            MoveInDirection ( CharacterMoveDirection.Left );
        }
    }

    private void IncrementScore ( )
    {
        _model.score += 1;
        ScoreIncreased.Invoke ( _model.score );
        Debug.Log ( _model.score);
    }

    private void PlayerDeath ( )
    {
        PlayerDead.Invoke ( );
        Dead ( );
    }

    /// <summary>
    /// Pool initialized from PlayerController.
    /// </summary>
    /// <param name="projectile"></param>
    /// <param name="poolSize"></param>
    private void InitializeProjectilePool ( Projectile projectile, int poolSize )
    {
        _model._projectilePool = new List<Projectile> ( poolSize );
        for ( int i = 0; i < poolSize; i++ )
        {
            Projectile p = Instantiate<Projectile> ( projectile );
            p.gameObject.SetActive ( false );
            _model._projectilePool.Add ( p );
        }
    }

    public void MoveLeft ( bool pressed )
    {
        _movingLeft = pressed;
    }

    public void MoveRight ( bool pressed )
    {
        _movingRight = pressed;
    }

    public void Shoot ( )
    {
        Projectile prjctl = _model.GetNextValidProjectile ( );
        if ( prjctl == null )
            return;

        prjctl.gameObject.SetActive ( true );
        prjctl.transform.position = _view._shooter.position;
        prjctl._rigidBody.velocity = _view.transform.forward * _model._projectileSpeed;
    }

    public void Jump ( )
    {
        if ( _view.IsGrounded ( ) )
        {
            _view._rigidBody.AddForce ( Vector3.up * _model._jumpForceMultiplier, ForceMode.Impulse );
        }
    }
}