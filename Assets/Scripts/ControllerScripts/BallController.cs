using UnityEngine;
using System.Collections;
using System;

public class BallController : MonoBehaviour {

    public float speed = 200.0f;
    public GameObject owner;

    private Rigidbody body;
    private float direction = 0;
    private bool ballIsActive = false;

    void Start()
    {
        switch (PlayerPrefs.GetInt("Difficulty")) {
            case 0: speed = 200.0f; break;
            case 1: speed = 200.0f; break;
            case 2: speed = 250.0f; break;
            default: speed = 200.0f; break;
        }

        direction = owner.tag.Equals("PaddlePlayerOne") ? 1.0f : -1.0f;
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ShootOne") && !ballIsActive && owner.tag.Equals("PaddlePlayerOne"))
        {
            Debug.Log("Entered Shoot One trigger");
            ballIsActive = true;
            PerformMovement();
        }
        if (Input.GetButtonDown("ShootTwo") && !ballIsActive && owner.tag.Equals("PaddlePlayerTwo"))
        {
            Debug.Log("entered Shoot Two Trigger");
            ballIsActive = true;
            PerformMovement();
        }
        if (!ballIsActive)
        {
            MoveBallOnPaddle();
        }
        //TODO::Remove this later!
        if (Input.GetButtonDown("Test"))
        {
            body.AddForce(0,0,1.0f);
            Debug.Log("Added test force");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PaddlePlayerOne") || collision.gameObject.tag.Equals("PaddlePlayerTwo"))
        {
            //Todo check if works maybe replace?
            GameObject paddle = collision.gameObject;
            Vector3 v = body.velocity;
            v.Normalize();
            float dotOfvn = Vector3.Dot(v, (direction == 1.0f ? Vector3.left : Vector3.right));

            Vector3 R = new Vector3();
            R += -2 * dotOfvn * (direction == 1.0f ? Vector3.left : Vector3.right);
            //TODO: finish method 
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
        //TODO: Calculate start angle
        /*  MAX_Y_SPEED = 30 // the maximum speed the ball could have on the Y axis
        *   coef = (ball.y - paddle.y) / (paddle.height * 0.5) // this will give you a number between -1 (top) and 1 (bottom)
        *   ball.speedY  = MAX_Y_SPEED * coef
        */
        float maxSpeedY = 150.0f;
        float coeff = (transform.localPosition.y - owner.transform.localPosition.y) / (owner.transform.localScale.y * 0.5f);
        Debug.Log("Logging start coeff: " + coeff); 
        body.AddForce(speed * direction, maxSpeedY * coeff, 0);
    }

    void MoveBallOnPaddle()
    {
        if (transform.localPosition.y < owner.transform.localPosition.y + (owner.transform.localScale.y / 2)
            && transform.localPosition.y > owner.transform.localPosition.y - (owner.transform.localScale.y / 2))
        {
            Debug.Log("On the paddle");
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, CalculateClosest(), transform.localPosition.z);
        }
    }

    float CalculateClosest()
    {
        float upper = owner.transform.localPosition.y + (owner.transform.localScale.y / 2);
        float downer = owner.transform.localPosition.y - (owner.transform.localScale.y / 2);

        float Difupper = upper;
        float Difdowner = downer;

        if (upper < 0)
            Difupper *= -1.0f;
        if (downer < 0)
            Difdowner *= -1.0f;
        

        float origin = transform.localPosition.y;

        float distUp = Difupper - origin;
        float distDown = Difdowner - origin;

        return distUp > distDown ? downer : upper;
    }
}