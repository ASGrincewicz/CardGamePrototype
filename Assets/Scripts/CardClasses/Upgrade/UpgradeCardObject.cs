using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UpgradeCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Upgrade Card")]
public class UpgradeCardObject:CardObject<UpgradeCard>// INHERITANCE
{
   [SerializeField] protected new UpgradeCard _thisCard;
    
    protected override void SetCard(UpgradeCard card)
    {
        if (_thisCard.ThisCardType != CardType.Upgrade)
        {
            Debug.Log($"{_thisCard.ThisCardType} should not be of type: UpgradeCard. Please check the Card Type.");
            _isTypeVerified = false;
        }
        else if (_thisCard.Power > 0 && _thisCard.ThisUpgradeType != UpgradeCard.UpgradeType.Weapon)
        {
            _isTypeVerified = false;
            Debug.Log($"Only Weapons should have a Power > 0. It is currently set to {_thisCard.Power}.");
        }
        else
        {
            _thisCard = card;
            _isTypeVerified = true;
            _title = _thisCard.Title;
            _cardNumber = _thisCard.CardNumber;
        }
    }
    
}
