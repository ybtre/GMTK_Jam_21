using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using System.Reflection;

public class Rope : MonoBehaviour
{
    public GameObject StartObject;
    public GameObject EndObject;
    public float MaxLength = 12f;

    GameObject[] _segments;

    private void Start()
    {
        GenerateSegments();
        _segments.Last().transform.position = EndObject.transform.position;
        ConnectSegment(EndObject, _segments.Last());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateSegments()
    {
        int totalSegments = Mathf.RoundToInt(Mathf.Max(Vector3.Distance(StartObject.transform.position, EndObject.transform.position), MaxLength));
        _segments = new GameObject[totalSegments];
        Vector3 segmentScale = new Vector3(0.1f, 0.1f, 0.1f);

        _segments[0] = GenerateSegment("_segment_0", StartObject.transform.position, segmentScale);
        GameObject previousSegment = _segments[0];

        for (int i = 1; i < totalSegments; ++i)
        {
            Vector3 segmentPosition = previousSegment.transform.position + new Vector3(0f, -0.2f, 0f);
            var segment = GenerateSegment($"_segment_{i}", segmentPosition, segmentScale);

            ConnectSegment(segment, previousSegment);

            previousSegment = segment;
            _segments[i] = segment;
        }
    }

    private GameObject GenerateSegment(string name, Vector3 position, Vector3 scale)
    {
        var segment = new GameObject
        {
            name = name
        };

        segment.transform.parent = transform;
        segment.transform.position = position;
        segment.transform.localScale = scale;

        segment.AddComponent<CapsuleCollider>().height = 2f;

        var joint = segment.AddComponent<HingeJoint>();
        joint.anchor = new Vector3(0f, 1f, 0f);
        joint.enableCollision = true;

        JointSpring spring = joint.spring;
        spring.spring = 25f;
        spring.damper = 50f;
        joint.useSpring = true;
        joint.spring = spring;

        var physBody = segment.GetComponent<Rigidbody>();
        physBody.mass = 0.25f;
        physBody.drag = 1f;
        physBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        return segment;
    }

    private void ConnectSegment(GameObject segment, GameObject to)
    {
        if (segment.TryGetComponent(out HingeJoint joint))
        {
            joint.connectedBody = to.GetComponent<Rigidbody>();
            joint.connectedAnchor = new Vector3(0f, -1f, 0f);
        }
    }

    public int GetSegmentCount()
    {
        return _segments.Length;
    }

    public Transform GetSegmentTransform(int index)
    {
        return _segments[index].transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (StartObject != null)
        {
            Gizmos.DrawWireSphere(StartObject.transform.position, 0.25f);

        }
        
        if (EndObject != null)
        {
            Gizmos.DrawWireSphere(EndObject.transform.position, 0.25f);

        }
    }
}
