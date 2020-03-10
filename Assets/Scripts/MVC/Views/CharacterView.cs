using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// MVC View for Character.
/// Has some basic common properties and bool check implementation for whether the character is on ground.
/// </summary>
public class CharacterView : MonoBehaviour
{
    public LayerMask _groundLayer;
    public LayerMask _opponentLayer;
    public Rigidbody _rigidBody { get; set; }
    public Collider _collider { get; set; }
    public Action CharacterKilled;

    /// <summary>
    /// Checks if character is on ground.
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded ( )
    {
        return Physics.Raycast(transform.position, Vector3.down,
            _collider.bounds.extents.y + 0.05f
            , _groundLayer );
    }
}