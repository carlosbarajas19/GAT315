using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Body bodyA { get; set; }
    public Body bodyB { get; set; }

    public float restLength { get; set; }
    public float k { get; set; }

    public void ApplyForce()
    {
        Vector2 direction = bodyA.position - bodyB.position;
        float length = direction.magnitude;
        float x = length - restLength;
        float f = -k * x;

        bodyA.ApplyForce(f * direction.normalized,Body.eForceMode.Force);
        bodyB.ApplyForce(-f * direction.normalized,Body.eForceMode.Force);
    }

}
