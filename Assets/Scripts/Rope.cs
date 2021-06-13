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
        Vector3 segmentScale = new Vector3(1f, 1f, 1f);

        _segments[0] = GenerateSegment("_segment_0", StartObject.transform.position, segmentScale);
        ConnectSegment(_segments[0], StartObject);
        GameObject previousSegment = _segments[0];

        for (int i = 1; i < totalSegments; ++i)
        {
            Vector3 segmentPosition = previousSegment.transform.position + new Vector3(0f, 0.2f, 0f);
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

        var collider = segment.AddComponent<CapsuleCollider>();
        collider.height = 0.4f;
        collider.radius = 0.2f;

        var joint = segment.AddComponent<HingeJoint>();
        joint.anchor = Vector3.zero;
        joint.axis = Vector3.zero;
        joint.enableCollision = true;

        JointSpring spring = joint.spring;
        spring.spring = 1f;
        spring.damper = 50f;
        spring.targetPosition = 70f;
        joint.useSpring = true;
        joint.spring = spring;

        joint.enablePreprocessing = false;

        var physBody = segment.GetComponent<Rigidbody>();
        physBody.mass = 2f;
        physBody.drag = 1f;
        physBody.angularDrag = 500f;
        physBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        return segment;
    }

    private void ConnectSegment(GameObject segment, GameObject to)
    {
        if (segment.TryGetComponent(out HingeJoint joint))
        {
            joint.connectedBody = to.GetComponent<Rigidbody>();
            joint.connectedAnchor = Vector3.zero;
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
