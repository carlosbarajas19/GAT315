using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : Force
{
    [SerializeField] FloatData gravity;

    public override void ApplyForce(List<Body> bodies)
    {
        bodies.ForEach(body => body.ApplyForce(Vector2.down * gravity.value, Body.eForceMode.Acceleration));
    }
}
