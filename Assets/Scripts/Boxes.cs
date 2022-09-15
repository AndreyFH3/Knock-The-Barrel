using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boxes : MonoBehaviour
{
    private AudioSource aSource;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private LayerMask changeTo;
    [SerializeField] private Sprite _brokeBox;
    [SerializeField] private float _touchStrenght;

    private BoxCounter boxCounter;
    [HideInInspector]public bool isTouched = false;
    private Rigidbody2D rb;
    private bool isStart = false;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(changeIsStart), 1.5f);
    }

    private void OnEnable()
    {
        if(boxCounter == null)
        {
            boxCounter = FindObjectOfType<BoxCounter>();
            ++boxCounter.boxCount;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Rigidbody2D rb2D))
        {
            if (rb2D.velocity.magnitude > _touchStrenght)
            {
                AddPoints();
            }
        }

        else if (rb.velocity.magnitude > _touchStrenght)
        {
            AddPoints();
        }
        if (!aSource.isPlaying && isStart)
            aSource.Play();
    }

    private void changeIsStart() => isStart = true;

    public void AddPoints()
    {
        if (isTouched) return;
        gameObject.layer = 6;
        isTouched = true;
        ++boxCounter.destroyedBox;

        particle.Play();
        GetComponent<SpriteRenderer>().sprite = _brokeBox;
        Invoke(nameof(End), 2f);
    }

    private void End()
    {
        particle.Stop();
        Destroy(gameObject, 1f);
    }

}
