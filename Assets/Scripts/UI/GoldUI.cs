using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] PlayerGold playerGold = null;

    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        ChangeGoldValue(playerGold.Gold);
        playerGold.GoldChanged += ChangeGoldValue;
    }
    private void ChangeGoldValue(float gold)
    {
        _textMeshPro.text = $"Gold: { gold }";
    }
    private void OnDestroy()
    {
        playerGold.GoldChanged -= ChangeGoldValue;
    }
}
