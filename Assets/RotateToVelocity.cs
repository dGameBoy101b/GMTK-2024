using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    void Update()
    {
        Vector2 velocity = rigidbody2D.velocity;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
