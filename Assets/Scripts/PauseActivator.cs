using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseActivator : MonoBehaviour
{
    [SerializeField] private Button pauseActive;
    [SerializeField] private Button pauseDisable;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject ballThr;
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector2 velocity;
    private void OnEnable()
    {
        pauseActive.onClick.AddListener(ActivatePause);
        pauseDisable.onClick.AddListener(DisablePause);
    }

    private void OnDisable()
    {
        pauseActive.onClick.RemoveListener(ActivatePause);
        pauseDisable.onClick.RemoveListener(DisablePause);
    }


    private void ActivatePause()
    {
        ball.GetComponent<Ball>().DesactiveRb();
        velocity = ball.GetComponent<Rigidbody2D>().velocity;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ballThr.SetActive(false);
        pauseCanvas.SetActive(true);
    }
    private void DisablePause() 
    {
        if(velocity.magnitude > 0)
            ball.GetComponent<Ball>().ActiveRb();
        else 
            ball.GetComponent<Ball>().DesactiveRb();
        ball.GetComponent<Rigidbody2D>().velocity = velocity;
        ball.SetActive(true);

        ballThr.SetActive(true);
        pauseCanvas.SetActive(false); 
    }
}
