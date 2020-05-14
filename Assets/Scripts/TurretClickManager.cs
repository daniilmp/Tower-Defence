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
                _lastHit.GetComponent<HasUpgradableUI>()?.SetActiveUpgradeUI(false);
            }
            _lastHit = hit.transform.GetComponent<Turret>();
            _lastHit.GetComponent<HasUpgradableUI>()?.SetActiveUpgradeUI(true);
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
            _lastHit.GetComponent<HasUpgradableUI>()?.SetActiveUpgradeUI(false);
            _lastHit = null;
        }
    }
}
