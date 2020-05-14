using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour, IPath
{
    public List<Transform> PathNodes { get; private set; }
    private void Awake()
    {
        PathNodes = GetPathNodes();
    }
    private List<Transform> GetPathNodes()
    {
        List<Transform> pathNodes = new List<Transform>();
        foreach (Transform childTransform in transform)
        {
            pathNodes.Add(childTransform);
        }
        return pathNodes;
    }

}
