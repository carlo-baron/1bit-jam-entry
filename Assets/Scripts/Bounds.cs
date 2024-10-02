using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    EdgeCollider2D edge;

    void Awake(){
        edge = GetComponent<EdgeCollider2D>();
    }

    public void UpdateBounds()
    {
        Rigidbody2D rb = transform.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
        CompositeCollider2D comp = transform.AddComponent<CompositeCollider2D>();
        comp.geometryType = CompositeCollider2D.GeometryType.Polygons;
        comp.GenerateGeometry();

        int pathCount = comp.pathCount;
        List<Vector2> edgePoints = new List<Vector2>();

        for (int i = 0; i < pathCount; i++)
        {
            Vector2[] points = new Vector2[comp.GetPathPointCount(i)];
            comp.GetPath(i, points);
            edgePoints.AddRange(points);
            edgePoints.Add(points[0]);
        }
        edge.points = edgePoints.ToArray();

        Destroy(comp);
        Destroy(rb);
    }
}
