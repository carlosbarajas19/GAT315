using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShape : Shape
{
    public override float size { get => transform.localScale.x; set => transform.localScale = Vector2.one * value; }

    public override float area => radius * radius * Mathf.PI;

    public float radius => size * 0.5f;

    public override AABB GetAABB(Vector2 position)
    {
        return new AABB(position, Vector2.one * size);
    }
    
}
