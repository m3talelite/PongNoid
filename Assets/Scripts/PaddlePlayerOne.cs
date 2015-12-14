using UnityEngine;
using System.Collections;

public class PaddlePlayerOne : MonoBehaviour {

    public float paddleSpeed = 1f;
    private Vector3 playerPosition = new Vector3(-6.75f, 0, 0);

	// Update is called once per frame
	void Update () {
        	
	}
    void FixedUpdate()
    {
        float posY = transform.position.y + (Input.GetAxis("Vertical") * paddleSpeed);
        playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -3.5f, 3.5f), playerPosition.z);
        transform.position = playerPosition;
    }
}
