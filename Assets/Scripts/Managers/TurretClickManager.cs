using UnityEngine;

public class TurretClickManager : MonoBehaviour
{
    Turret _lastHit;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100.0f))
        {
            DeactivateUpgradeUI();
            return;
        }

        if (hit.transform.CompareTag("Turret"))
        {
            if (_lastHit != null && _lastHit != hit.transform.GetComponent<Turret>())
            {
                _lastHit.GetComponent<IHasUpgradableUI>()?.SetActiveUpgradeUI(false);
            }
            _lastHit = hit.transform.GetComponent<Turret>();
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
