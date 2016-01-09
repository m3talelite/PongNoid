using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

    public float paddleSpeed = 0.1f;

    private Vector3 playerPosition;

	void Start()
    {
        playerPosition = gameObject.tag.Equals("PaddlePlayerOne") ? new Vector3(-6.75f, 0, 0) : new Vector3(6.75f, 0, 0);
        switch (PlayerPrefs.GetInt("Difficulty")) { 
            case 0: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); paddleSpeed = 0.1f; break;
            case 1: transform.localScale = new Vector3(0.25f, 2.5f, 0.5f); paddleSpeed = 0.12f; break;
            case 2: transform.localScale = new Vector3(0.25f, 1.5f, 0.5f); paddleSpeed = 0.14f; break;
            default: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); paddleSpeed = 0.1f; break;
        }
    }

    void FixedUpdate()
    {
        if (gameObject.tag.Equals("PaddlePlayerOne")) {
            float posY = transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), playerPosition.z);
            transform.position = playerPosition;
        } 
        else {
            float posY = transform.position.y + (Input.GetAxis("VerticalTwo") * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), playerPosition.z);
            transform.position = playerPosition;
        }
    }
}
