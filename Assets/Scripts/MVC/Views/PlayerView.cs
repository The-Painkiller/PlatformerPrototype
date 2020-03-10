using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// MVC View for Player.
/// Collision checks handle:
////// 1) Getting killed by hitting enemy if not stomping from right on top.
////// 2) Fell into the abyss and died.
////// 3) Touched castle(just the last cube really) and won.
///
/// Trigger check at this point only checks if it touched coins.
/// </summary>
public class PlayerView : CharacterView
{
    public Transform _shooter;
    public Projectile _projectilePrefab;

    public Action CastleTouched;
    public Action CoinCollected;
    
    private void Awake ( )
    {
        _collider = GetComponent<Collider> ( );
        _rigidBody = GetComponent<Rigidbody> ( );
        Debug.Log ( _collider.bounds.extents);
    }

    bool IsStompingEnemy ( )
    {
        Debug.DrawRay ( transform.position, Vector3.down, Color.white, 0.5f );
        Debug.Log ( _opponentLayer.value );
        return Physics.Raycast ( transform.position, -transform.up, _collider.bounds.extents.y + 0.5f
            , _opponentLayer );
    }

    private void Update ( )
    {
        Debug.DrawRay ( transform.position, Vector3.down, Color.white, 0.5f );
    }

    private void OnCollisionEnter ( Collision collision )
    {
        if ( ( _opponentLayer & 1 << collision.gameObject.layer ) == 1 << collision.gameObject.layer )
        {
            Debug.Log ("IsStomping: " + IsStompingEnemy() );

            if ( !IsStompingEnemy ( ) )
                CharacterKilled.Invoke ( );
        }
        else if ( collision.gameObject.tag == "KillVolume" )
        {
            CharacterKilled.Invoke ( );
        }
        else if ( collision.gameObject.tag == "Castle" )
        {
            CastleTouched.Invoke ( );
        }
    }

    private void OnTriggerEnter ( Collider trigger )
    {
        if ( trigger.tag == "Coin" )
        {
            CoinCollected.Invoke ( );
        }
    }
}
