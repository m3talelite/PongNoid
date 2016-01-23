using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BallController : MonoBehaviour {

    public float speed = 200.0f;
    public GameObject owner;

    private Rigidbody body;
    private float direction = 0;
    private bool ballIsActive = false;
	private bool isInCollision = false;

	private int playerScore = 0;
	public Text playerScoreText;

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

		UpdatePlayerScore ();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ShootOne") && !ballIsActive && owner.tag.Equals("PaddlePlayerOne"))
        {
            ballIsActive = true;
            PerformMovement();
        }
        if (Input.GetButtonDown("ShootTwo") && !ballIsActive && owner.tag.Equals("PaddlePlayerTwo"))
        {
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
            GameObject paddle = collision.gameObject;
            float maxSpeedY = 2.0f;
            float coeff = (transform.localPosition.y - paddle.transform.localPosition.y) / (paddle.transform.localScale.y * 0.5f);
            if (coeff != 0 && body.velocity.y != 0) {
                body.velocity = new Vector3(body.velocity.x, coeff * maxSpeedY + body.velocity.y, body.velocity.z);
            }
        }
    }

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag.Equals("Block"))
		{
			body.velocity = new Vector3(body.velocity.x * -1, body.velocity.y, body.velocity.z);

			if (collider.gameObject.GetComponent<BasicBlock>() is BasicBlock) {
				BasicBlock block = collider.gameObject.GetComponent<BasicBlock>();
				block.DecreaseToughness();

				if (block.getIsBreakable() && block.getToughness() == 0){
					++playerScore;
					UpdatePlayerScore ();
					Destroy (collider.gameObject);
				}
			}

			if (collider.gameObject.GetComponent<ToughBlock>()is ToughBlock){
				ToughBlock block = collider.gameObject.GetComponent<ToughBlock>();
				block.DecreaseToughness();

				if(block.getIsBreakable() && block.getToughness() == 0) {
					playerScore += 5;
					UpdatePlayerScore ();
					Destroy (collider.gameObject);
				}
			}

			Debug.Log(playerScore);
		}
	}

	void UpdatePlayerScore() {
		playerScoreText.text = playerScore.ToString ();
	}

    void PerformMovement()
    {
        float maxSpeedY = 150.0f;
        float coeff = (transform.localPosition.y - owner.transform.localPosition.y) / (owner.transform.localScale.y * 0.5f);
        body.AddForce(speed * direction, maxSpeedY * coeff, 0);
    }

    void MoveBallOnPaddle()
    {
        if (transform.localPosition.y < owner.transform.localPosition.y + (owner.transform.localScale.y / 2)
            && transform.localPosition.y > owner.transform.localPosition.y - (owner.transform.localScale.y / 2))
        {
        
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