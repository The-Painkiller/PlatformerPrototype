using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic coin implementation.
/// Trigger check prevents Enemy or Projectile to deactivate the coin.
/// </summary>
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter ( Collider other )
    {
        if ( LayerMask.LayerToName ( other.gameObject.layer ) == "Enemy" )
            return;

        if ( other.tag == "Projectile" )
            return;

        gameObject.SetActive ( false );
    }
}
