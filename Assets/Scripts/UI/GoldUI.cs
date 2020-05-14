using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        ChangeGoldValue(GoldManager.Instance.Gold);
        GoldManager.Instance.GoldChanged += ChangeGoldValue;
    }
    private void ChangeGoldValue(float gold)
    {
        _textMeshPro.text = $"Gold: { gold }";
    }
    private void OnDestroy()
    {
        GoldManager.Instance.GoldChanged -= ChangeGoldValue;
    }
}
