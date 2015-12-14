using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {

    public float ballInitialSpeed = 600.0f;
    public GameObject owner;

    private Rigidbody body;
    private float direction;
    private bool ballIsActive = false;

    void Start()
    {
        owner = GetComponent<GameObject>();
        body = GetComponent<Rigidbody>();

        direction = owner.tag.Equals("PaddlePlayerOne") ? 1.0f : -1.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("ShootOne") && !ballIsActive)
        {
            //TODO: Calculate start angle
            /*  MAX_Y_SPEED = 30 // the maximum speed the ball could have on the Y axis
            *   coef = (ball.y - paddle.y) / (paddle.height * 0.5) // this will give you a number between -1 (top) and 1 (bottom)
            *   ball.speedY  = MAX_Y_SPEED * coef
            */
            Debug.Log("Entered Shoot One trigger");
            ballIsActive = true;
            PerformMovement();
        }
        if (Input.GetButtonDown("ShootTwo") && !ballIsActive)
        {
            Debug.Log("entered Shoot Two Trigger");
            ballIsActive = true;
            PerformMovement();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PaddlePlayerOne") || collision.gameObject.tag.Equals("PaddlePlayerTwo"))
        {
            Debug.Log("Ball hit paddle");
        }
        if (collision.gameObject.tag.Equals("Block"))
        {
            //Add Points?
            Debug.Log("Block hit");
        }
    }

    void PerformMovement()
    {
        body.AddForce(ballInitialSpeed, ballInitialSpeed * direction, 0);
    }
}
