using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public abstract float size { get; set; }
    public abstract float area { get; }

    public float mass => area * density;
    public float density { get; set; } = 1;

    public Color color { set => spriteRenderer.material.color = value; }
    public abstract AABB GetAABB(Vector2 position);

}
