using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForce : Force
{
    [SerializeField] BoolData global;
    [SerializeField] FloatData k;
    [SerializeField] FloatData length;

    public override void ApplyForce(List<Body> bodies)
    {
        if (global.value)
        {
            bodies.ForEach(body => body.springs.ForEach(spring => 
            { 
                spring.k = k.value;
                spring.restLength = length.value;
            }));
        }

        bodies.ForEach(body => body.springs.ForEach(spring => spring.ApplyForce()));

    }
}