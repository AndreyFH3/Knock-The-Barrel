using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwBall : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float pushForce;
    [SerializeField] private trajectory _trajectory;

    [SerializeField] private Control _control;
    private bool isDrag;
    private Camera cam;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private Vector2 force;
    private float distance;
    [SerializeField, Range(0, 1)] private float _maxForce;

    private void OnEnable()
    {
        _control?.Enable();
    }
    private void OnDisable()
    {
        _control?.Disable();
    }

    private void Start()
    {
        _control = new Control();
        _control?.Enable();

        _control.Game.activeTajectory.performed += _ => { isDrag = true; OnDragStart(); };
        _control.Game.activeTajectory.canceled += _ => { isDrag = false; OnDragEnd(); };
        cam = Camera.main;
        ball.DesactiveRb();
    }

    private void Update()
    {
        if(isDrag)
            OnDrag();
    }

    private void OnDragStart()
    {
        _trajectory.Show();
        ball.DesactiveRb();
        startPos = cam.ScreenToWorldPoint(_control.Game.position.ReadValue<Vector2>());
    }

    private void OnDrag()
    {
        endPos = cam.ScreenToWorldPoint(_control.Game.position.ReadValue<Vector2>());
        distance = Vector2.Distance(startPos,endPos);
        direction = (startPos - endPos).normalized;
        force = pushForce * distance * direction;

        Vector2 maxForce = Vector2.ClampMagnitude(force, _maxForce);
        force *= _maxForce;

        _trajectory.UpdateDots(ball.defaultPosition, force);

        Debug.DrawLine(startPos,endPos);
    }

    private void OnDragEnd()
    {
        _trajectory.Hide();
        ball.ActiveRb();
        ball.Push(force);
    }
}
