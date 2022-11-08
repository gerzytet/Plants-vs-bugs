using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlant : Plant
{
    public override void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        Grow();
    }

    public override void Grow()
    {
        base.Grow();
    }
}
