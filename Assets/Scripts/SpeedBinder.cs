using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBinder : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;

    void Update()
    {
        animator.SetFloat("Speed", rigidbody2D.velocity.magnitude);
    }
}
