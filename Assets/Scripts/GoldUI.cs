using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private GoldManager _goldManager;
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _goldManager = FindObjectOfType<GoldManager>();
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        ChangeGoldValue(_goldManager.Gold);
        _goldManager.GoldChanged += ChangeGoldValue;
    }
    private void ChangeGoldValue(float gold)
    {
        _textMeshPro.text = $"Gold: { gold }";
    }
}
