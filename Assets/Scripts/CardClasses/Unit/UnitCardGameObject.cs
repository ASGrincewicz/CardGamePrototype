using UnityEngine;
using System;
using TMPro;
/// <summary>
/// Used to represent Unit Cards during gameplay.
/// Must have UnitCardObject assigned
/// in order to function.
/// </summary>
public class UnitCardGameObject :CardGameObject// INHERITANCE
{
    [SerializeField] private Color[] _unitTypeColors = new Color[4];
    [SerializeField] private TMP_Text _hPText = null;
    [SerializeField] private TMP_Text _powerText = null;

    protected override void OnValidate()
    {
        try
        {
            if (!_cardSO.TypeVerified)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
            {
                _isCardVerified = true;
                if (this.gameObject.activeInHierarchy)
                    this.gameObject.name = $"{_cardSO.CardNumber}_{_cardSO.Title}_card";

                SetColors((int)_cardSO.ThisCardType);
                SetText();
            }
        }
        catch (NullReferenceException ex)
        {
            if (this.gameObject.activeInHierarchy)
                Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }// INHERITANCE
    protected override void SetColors(int unitTypeColor)
    {
        _cardBorder.color = _rarityColors[(int)_cardSO.Rarity];
        _cardImage.color = _unitTypeColors[unitTypeColor];
    }
}
