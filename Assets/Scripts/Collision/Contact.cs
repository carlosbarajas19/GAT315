using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact 
{
    public Body bodyA;
    public Body bodyB;

    public float depth;
    public Vector2 normal;

    public class ItemEqualityComparer : IEqualityComparer<Contact>
    {
        public bool Equals(Contact contactA, Contact contactB)
        {
            // Two items are equal if their keys are equal.
            return ((contactA.bodyA == contactB.bodyA && contactA.bodyB == contactB.bodyB) ||
                (contactA.bodyA == contactB.bodyB && contactA.bodyB == contactB.bodyA));
        }



        public int GetHashCode(Contact obj)
        {
            return obj.GetHashCode();
        }
    }
}
