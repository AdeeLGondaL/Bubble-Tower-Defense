using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Action<CannonBall> killAction;

    public void Init(Action<CannonBall> killAction)
    {
        this.killAction = killAction;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Plane")) killAction(this);
    }
}
