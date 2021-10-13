using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UnitCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Unit Card")]
public class UnitCardObject: CardObject// INHERITANCE
{
    [SerializeField] protected UnitCard _thisUnitCard;
    public UnitCard GetCard() => _thisUnitCard;
    protected override void SetCard(UnitCard card)
    {
        switch (card.ThisCardType)
        {
            case CardType.Action:
            case CardType.Location:
            case CardType.Upgrade:
                Debug.Log($"{_thisUnitCard.ThisCardType} should not be of type: UnitCard. Please check the Card Type.");
                _isTypeVerified = false;
                break;
            default:
                _thisUnitCard = card;
                _isTypeVerified = true;
                _title = _thisUnitCard.Title;
                _cardNumber = _thisUnitCard.CardNumber;
                _cardText = _thisUnitCard.CardText;
                _rarity = _thisUnitCard.Rarity;
                _cardType = _thisUnitCard.ThisCardType;
                break;
        }
    }
    private void OnValidate()
    {
        try
        {
            SetCard(_thisUnitCard);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log($"Please assign a {_thisUnitCard} card to this game object.");
        }
    }
}
