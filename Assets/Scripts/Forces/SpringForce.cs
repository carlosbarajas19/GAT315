using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForce : Force
{
    public override void ApplyForce(List<Body> bodies)
    {
        bodies.ForEach(body => body.springs.ForEach(spring => spring.ApplyForce()));

    }
}