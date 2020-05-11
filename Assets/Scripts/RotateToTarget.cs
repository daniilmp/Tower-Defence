using UnityEngine;

public class RotateToTarget: MonoBehaviour
{
    private Transform _target;
    private void Update()
    {
        if(_target)
            LockOnTarget(_target);
    }
    public void ChangeTarget(Transform target)
    {
        _target = target;
    }
    private void LockOnTarget(Transform target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, lookRotation.eulerAngles.y, 0), Time.deltaTime * 10);
    }
}
