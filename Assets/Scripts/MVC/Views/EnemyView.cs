using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// MVC View for Enemy.
/// OnCollision check:
////// 1) Detects wall and changes direction.
////// 2) Checks if hit with opponent's layer is resulting in it getting stomped from the top. Calls 'Killed' if so.
////// 3) Checks if it got hit by projectile or fell into the abyss. Calls 'Killed' if so.
/// </summary>
public class EnemyView : CharacterView
{
    public Action WallTouched;

    private void Awake ( )
    {
        _collider = GetComponent<Collider> ( );
        _rigidBody = GetComponent<Rigidbody> ( );
    }

    bool IsGettingStomped ( )
    {
        return Physics.Raycast ( transform.position, Vector3.up, _collider.bounds.extents.y + 0.5f
            , _opponentLayer );
    }

    private void OnCollisionEnter ( Collision collision )
    {
        if((_opponentLayer & 1 << collision.gameObject.layer) == 1<< collision.gameObject.layer)
        {
            if ( IsGettingStomped ( ) )
            {
                StartCoroutine ( KillCharacter ( ) );
            }
        }
        else if ( collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "KillVolume" )
        {
            StartCoroutine ( KillCharacter ( ) );
        }
        else if ( collision.gameObject.tag == "Wall" || collision.gameObject.layer == gameObject.layer )
        {
            WallTouched.Invoke ( );
        }
    }

    /// <summary>
    /// Done to avoid racing condition with Player's stomping logic that gave rise to player & enemy both dying.
    /// </summary>
    /// <returns></returns>
    IEnumerator KillCharacter ( )
    {
        yield return new WaitForEndOfFrame ( );
        CharacterKilled.Invoke ( );
    }
}
