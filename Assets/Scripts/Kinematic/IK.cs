using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    [SerializeField] IKSegment segmentPrefab;
    [SerializeField] int segmentCount = 5;
    [SerializeField] [Range(0.1f, 3.0f)] float size = 1;
    [SerializeField] [Range(0.1f, 3.0f)] float length = 1;

    [SerializeField] Transform targetTransform;
    [SerializeField] Transform anchor;

    List<IKSegment> segments = new List<IKSegment>();

    private void Start()
    {
        KinematicSegment parent = null;

        // create segments
        for (int i = 0; i < segmentCount; i++)
        {
            // create segment
            var segment = Instantiate(segmentPrefab, transform);
            segment.Initialize(parent, transform.position, transform.rotation.eulerAngles.z, length, size);
            // add segment
            segments.Add(segment);

            // set parent to current segment
            parent = segment;
        }
    }

    void Update()
    {
        // update segments
        foreach (var segment in segments)
        {
            // update size and length
            segment.size = size;
            segment.length = length;

            // set target to parent start if parent exists else set target to target transform position
            Vector2 target = (segment.parent != null) ? segment.parent.start : (Vector2) targetTransform.position;

            // call segment follow with target as parameter
            segment.Follow(target);
        }

        // if anchor is present
        if (anchor != null)
        {
            // start at the base (last segment = segment count - 1) 
            int base_index = segmentCount - 1;
            // set base segment start to anchor position
            segments[base_index].start = anchor.position;
            // iterate from the back to the front, setting segment start to next segment end
            
            for (int i = base_index - 1; i >= 0; i--)
            {
                segments[i].start = segments[i + 1].end;
            }
        }
    }

}
