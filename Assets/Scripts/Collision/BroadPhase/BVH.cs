using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BVH : BroadPhase
{
    BVHNode rootNode;

    public override void Build(AABB aabb, List<Body> bodies)
    {
        queryResultCount = 0;
        List<Body> sorted = new List<Body>(bodies);

        sorted.Sort((x, y) => x.position.x.CompareTo(y.position.x));

        // create BVH root node
        rootNode = new BVHNode(sorted);
    }

    public override void Query(AABB aabb, List<Body> results)
    {
        rootNode.Query(aabb, results);

        queryResultCount = queryResultCount + results.Count;
    }

    public override void Query(Body body, List<Body> results)
    {
        Query(body.shape.GetAABB(body.position), results);
    }

    public override void Draw()
    {
        rootNode?.Draw();
    }
}
