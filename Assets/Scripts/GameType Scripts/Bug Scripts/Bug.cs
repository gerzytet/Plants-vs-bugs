using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bug : GameType
{
    public virtual void Update()
    {
        GameObject spriteObject = transform.GetChild(1).gameObject;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        spriteObject.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, velocity));
    }
}
