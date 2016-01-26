using UnityEngine;
using System.Collections;

public abstract class Block : MonoBehaviour {
    protected int toughness;
    protected int point;
    protected bool hasSpecial;
    protected bool isBreakable;
    public abstract void GetPowerUp();

    public void DecreaseToughness()
    {
        if (isBreakable) {
            --toughness;
        }
    }

    public bool IsAlive()
    {
        return isBreakable ? (toughness > 0 ? true : false) : false;
    }

	public bool getIsBreakable(){
		return isBreakable;
	}
	public int getToughness(){
		return toughness;
	}
    public int getPoint()
    {
        return point;
    }
}
