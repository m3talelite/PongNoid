using UnityEngine;
using System.Collections;

public class PearRotator : MonoBehaviour {

    private float ranVal;

    // Use this for initialization
    void Start () {
        this.ranVal = Random.value * 20 + 20;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(0, 0, this.ranVal) * Time.deltaTime);
    }
}
