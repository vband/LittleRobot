using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3
            (
            Mathf.Clamp(playerTransform.position.x, -4f, 4f),
            transform.position.y,
            transform.position.z
            );
    }
}
