using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// MVC Model for Player.
/// Has Projectile speed, jump force multiplier, score.
/// Has Object Pooling implemented for projectiles.
/// </summary>
public class PlayerModel : CharacterModel
{
    public float _projectileSpeed;
    public float _jumpForceMultiplier;
    public int score { get; set; }
    public List<Projectile> _projectilePool;

    /// <summary>
    /// Initialize model data here
    /// </summary>
    /// <param name="moveSpeed"></param>
    /// <param name="projectileSpeed"></param>
    /// <param name="jumpForceMultiplier"></param>
    public PlayerModel (float moveSpeed, float projectileSpeed, float jumpForceMultiplier )
    {
        _movementSpeed = moveSpeed;
        _projectileSpeed = projectileSpeed;
        _jumpForceMultiplier = jumpForceMultiplier;
    }

    /// <summary>
    /// Checks first projectile that is inactive(unused) and passes that to PlayerController for shooting.
    /// </summary>
    /// <returns></returns>
    public Projectile GetNextValidProjectile ( )
    {
        return _projectilePool.Find ( x => x.gameObject.activeInHierarchy == false );
    }
}
