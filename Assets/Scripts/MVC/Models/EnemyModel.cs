using UnityEngine;
using System.Collections;

/// <summary>
/// MVC Model for Enemy.
/// Dummy as of now as the enemy is very basic with no particular properties of its own.
/// This can very well be extended later for more elaborate enemies.
/// </summary>
public class EnemyModel : CharacterModel
{

    /// <summary>
    /// Initialize model data here
    /// </summary>
    /// <param name="moveSpeed"></param>
    public EnemyModel ( float moveSpeed )
    {
        _movementSpeed = moveSpeed;
    }
}
