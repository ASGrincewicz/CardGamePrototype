using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UpgradeCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName = "Card/Upgrade Card")]
public class UpgradeCardObject : CardObject// INHERITANCE
{
    [SerializeField] protected UpgradeCard _upgradeCard;
    public UpgradeCard GetCard() => _upgradeCard;
    protected override void SetCard(UpgradeCard card)
    {
        if (_upgradeCard.ThisCardType != CardType.Upgrade)
        {
            Debug.Log($"{_upgradeCard.ThisCardType} should not be of type: UpgradeCard. Please check the Card Type.");
            _isTypeVerified = false;
        }
        else if (_upgradeCard.Power > 0 && _upgradeCard.ThisUpgradeType != UpgradeCard.UpgradeType.Weapon)
        {
            _isTypeVerified = false;
            Debug.Log($"Only Weapons should have a Power > 0. It is currently set to {_upgradeCard.Power}.");
        }
        else
        {
            _upgradeCard = card;
            _isTypeVerified = true;
            _title = _upgradeCard.Title;
            _cardNumber = _upgradeCard.CardNumber;
            _cardText = _upgradeCard.CardText;
            _rarity = _upgradeCard.Rarity;
            _cardType = _upgradeCard.ThisCardType;
        }
    }
    private void OnValidate()
    {
        try
        {
            SetCard(_upgradeCard);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log($"Please assign a {_upgradeCard.ThisCardType} card to this game object.");
        }
    }
}
