using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Boxes bx))
        {
            if (!bx.isTouched)
                bx.AddPoints();
        }
    }
}
