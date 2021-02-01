using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    Vector2 paddletoballvector;
    bool hasStarted = false;
    [SerializeField] float xpush = 2f;
    [SerializeField] float ypush = 15f;
    [SerializeField] AudioClip[] ballSound;
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float paddleVelocityImpactPercentage = 0.3f;
    [SerializeField] float randomFactor = 0.2f;
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddletoballvector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasStarted)
        {
            lockballtopaddle();
            LaunchOnMouseclick();

        }
    }
    private void lockballtopaddle ()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + paddletoballvector;
    }
    private void LaunchOnMouseclick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2D.velocity = (new Vector2(Random.Range(-xpush, xpush), Random.Range(0.5f, ypush)).normalized)*ballSpeed;


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted == true)
        {
            AudioClip clip = ballSound[Random.Range(0, ballSound.Length)];
            audioSource.PlayOneShot(clip);

            Vector2 velocityTweek = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            if(collision.collider.CompareTag("Paddle"))
            {
                velocityTweek += collision.rigidbody.velocity * paddleVelocityImpactPercentage;

            }
            rigidbody2D.velocity = (rigidbody2D.velocity + velocityTweek).normalized * ballSpeed;
        }
    }
}
