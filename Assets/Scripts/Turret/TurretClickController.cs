using UnityEngine;

public class TurretClickController : MonoBehaviour
{
    Turret _lastHit;
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ShowTurretUpgradeUI();
        }
    }
    // Casts a ray from mouse position. If the ray hits a turret, turret's upgrade ui sets active
    private void ShowTurretUpgradeUI()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100.0f))
        {
            DeactivateUpgradeUI();
            return;
        }
        Turret turretHit = hit.transform.GetComponent<Turret>();
        if (turretHit)
        {
            if (_lastHit != null && _lastHit != turretHit)
            {
                _lastHit.GetComponent<IHasUpgradableUI>()?.SetActiveUpgradeUI(false);
            }
            _lastHit = turretHit;
            _lastHit.GetComponent<IHasUpgradableUI>()?.SetActiveUpgradeUI(true);
        }
        else
        {
            DeactivateUpgradeUI();
        }
        
    }
    void DeactivateUpgradeUI()
    {
        if (_lastHit != null)
        {
            _lastHit.GetComponent<IHasUpgradableUI>()?.SetActiveUpgradeUI(false);
            _lastHit = null;
        }
    }
}
