using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer Renderer;
    public Rope Rope;

    private void Start()
    {
        Renderer.positionCount = Rope.GetSegmentCount();
    }

    // Start is called before the first frame update
    void Update()
    {
        int totalPoints = Rope.GetSegmentCount();
        Renderer.positionCount = totalPoints;
        for (int i = 0; i < totalPoints; i++)
        {
            Renderer.SetPosition(i, Rope.GetSegmentTransform(i).position);
        }
    }
}
