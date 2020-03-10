using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Follow script.
/// Mostly basic and dummy at this point.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    public Vector3 _offset;

    private void LateUpdate ( )
    {
        transform.position = _target.position + _offset;
    }
}
