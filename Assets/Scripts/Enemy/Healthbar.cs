using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    private Slider _slider;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    public void UpdateHealth(float currentHealth)
    {
        _slider.value = currentHealth;
    }
}
