using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic player projectile class.
/// Will deactivate if touches any collider apart from Floor.
/// </summary>
public class Projectile : MonoBehaviour
{
    public Rigidbody _rigidBody { get; set; }

    private void Awake ( )
    {
        _rigidBody = GetComponent<Rigidbody> ( );
    }

    private void OnCollisionEnter ( Collision collision )
    {
        if ( collision.gameObject.tag == "Floor" )
            return;

        gameObject.SetActive ( false );
    }


}