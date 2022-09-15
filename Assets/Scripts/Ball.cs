using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 defaultPosition { get => transform.position; }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);

    }

    public void ActiveRb()
    {
        rb.freezeRotation = false;
        rb.isKinematic = false;
    }

    public void DesactiveRb()
    {
        rb.isKinematic = true;
        rb.freezeRotation = true;
        rb.velocity = Vector2.zero;
    }
}
