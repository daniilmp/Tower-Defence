using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillCount : MonoBehaviour
{
    private int _killCount = 0;

    public int GetKillCount()
    {
        return _killCount;
    }

    public void AddKill()
    {
        _killCount++;
    }

}
