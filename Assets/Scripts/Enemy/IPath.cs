using System.Collections.Generic;
using UnityEngine;

public interface IPath
{
    List<Transform> PathNodes { get; }
}