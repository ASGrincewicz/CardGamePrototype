using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UpgradeCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Upgrade Card")]
public class UpgradeCardObject:CardObject// INHERITANCE
{
    [SerializeField] private UpgradeCard _upgradeCard = new UpgradeCard();

    public UpgradeCard ThisUpgradeCard// ENCAPSULATION
    {
        get => _upgradeCard;
        set
        {
           if(_upgradeCard.ThisCardType != CardType.Upgrade)
           {
                Debug.Log($"{_upgradeCard.ThisCardType} should not be of type: UpgradeCard. Please check the Card Type.");
                _isTypeVerified = false;
           }
           else if(_upgradeCard.Power > 0 && _upgradeCard.ThisUpgradeType != UpgradeCard.UpgradeType.Weapon)
            {
                _isTypeVerified = false;
                Debug.Log($"Only Weapons should have a Power > 0. It is currently set to {_upgradeCard.Power}.");
            }
           else
            {
                _upgradeCard = value;
                _isTypeVerified = true;
                _title = _upgradeCard.Title;
                _cardNumber = _upgradeCard.CardNumber;
            }
        }
    }

    protected override void OnValidate()
    {
        try
        {
            ThisUpgradeCard = _upgradeCard;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Please assign an Upgrade Card to this game object.");
        }
    }
}
