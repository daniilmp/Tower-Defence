using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public static Transform[] PathNodes;
    private List<Transform> pathNodes;

    // TODO: fix this to List
    private void Awake()
    {
        PathNodes = new Transform[transform.childCount];
        for (int i = 0; i < PathNodes.Length; i++)
        {
            PathNodes[i] = transform.GetChild(i);
        }
    }
    public List<Transform> GetPathNodes()
    {
        List<Transform> pathNodes = new List<Transform>();
        foreach(Transform childTransform in transform)
        {
            pathNodes.Add(childTransform);
        }
        return pathNodes;
    }

}
