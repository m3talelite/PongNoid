using UnityEngine;
using System.Collections;
using System;

public class BasicBlock : Block{
    
    // Use this for initialization
    void Start () {
        isBreakable = true;
        toughness = 1;
        point = 1;
	}

    public override void GetPowerUp()
    {
        throw new NotImplementedException();
    }
}
