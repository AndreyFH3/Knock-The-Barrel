using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folllowCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField, Range(0, 1)] private float _speed;
    [SerializeField] private Transform _target;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        TargetFollow();
    }

    private void TargetFollow() =>
        transform.position = Vector3.Lerp(transform.position, _target.position + new Vector3(0, 0, -10), _speed);
    
}
