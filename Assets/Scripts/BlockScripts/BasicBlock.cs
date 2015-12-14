using UnityEngine;
using System.Collections;
using System;

public class BasicBlock : Block{
    
    // Use this for initialization
    void Start () {
        toughness = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (toughness <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        --toughness;
    }

    public override void OnCollision()
    {
    }

}
