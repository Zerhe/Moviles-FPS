using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proyectil : Objeto
{
    public abstract void AddVelocity();
    protected override void OnDisable()
    {
        base.OnDisable();
    }
}
