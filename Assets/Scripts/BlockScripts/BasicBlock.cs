using UnityEngine;
using System.Collections;
using System;

public class BasicBlock : Block{
    
    // Use this for initialization
    void Start () {
        isBreakable = true;
        toughness = 1;
	}
	
    void OnCollisionEnter(Collision collision)
    {
        DecreaseToughness();
    }

    public override void GetPowerUp()
    {
        throw new NotImplementedException();
    }
}
