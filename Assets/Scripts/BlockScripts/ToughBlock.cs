using UnityEngine;
using System.Collections;
using System;

public class ToughBlock : Block {
    // Use this for initialization
    void Start () {
        isBreakable = true;
        toughness = 5;
    }
    public override void GetPowerUp()
    {
        throw new NotImplementedException();
    }
}
