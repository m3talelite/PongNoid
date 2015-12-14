using UnityEngine;
using System.Collections;

public abstract class Block : MonoBehaviour {
    protected int toughness;
    protected bool hasSpecial;

    public void DecreaseToughness()
    {
        if (toughness <= 0)
        {
            Destroy(this);
        }
        else
        {
            --toughness;
        }
    }

    public abstract void OnCollision();
}
