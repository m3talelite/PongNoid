using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

    public float paddleSpeed = 0.2f;
    private Vector3 playerPosition;

	void Start()
    {
        playerPosition = gameObject.tag.Equals("PaddlePlayerOne") ? new Vector3(-6.75f, 0, 0) : new Vector3(6.75f, 0, 0);
    }

    void FixedUpdate()
    {
        if (gameObject.tag.Equals("PaddlePlayerOne"))
        {
            float posY = transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -3.5f, 3.5f), playerPosition.z);
            transform.position = playerPosition;
        } 
        else
        {
            float posY = transform.position.y + (Input.GetAxis("VerticalTwo") * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -3.5f, 3.5f), playerPosition.z);
            transform.position = playerPosition;
        }
    }
}
