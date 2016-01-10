using UnityEngine;
using System.Collections;

public abstract class Block : MonoBehaviour {
    protected int toughness;
    protected bool hasSpecial;
    protected bool isBreakable;
    public abstract void GetPowerUp();

    public void DecreaseToughness()
    {
        if (isBreakable) {
            --toughness;
        }
        if (isBreakable && !IsAlive()) {
            Destroy(this.gameObject);
        }
    }

    public bool IsAlive()
    {
        return isBreakable ? (toughness > 0 ? true : false) : false;
    }
}
