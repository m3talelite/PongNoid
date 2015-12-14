using UnityEngine;
using System.Collections;

public class BallPlayerOne : MonoBehaviour {

    public float ballInitialSpeed = 2f;

    private Rigidbody body;
    private bool ballIsActive = false;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Shoot") && !ballIsActive)
        {
            ballIsActive = true;
            body.MovePosition(new Vector3(body.position.x + ballInitialSpeed, body.position.y + ballInitialSpeed, body.position.z));
            Debug.Log("entered Shoot event");
        }
	}
}
