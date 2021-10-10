using UnityEngine;
using System;

[CreateAssetMenu(menuName ="Card/Unit/Character Card")]
public class CharacterCardObject : UnitCardObject
{
    protected override void SetCard(UnitCard card)
    {

        if (_thisUnitCard.ThisCardType != CardType.Unit)
        {
            Debug.Log($"{ _thisUnitCard.ThisCardType} should not be of type: Unit. Please check the Unit Type.");
            _isTypeVerified = false;
            if(_thisUnitCard.ThisUnitType != UnitType.Character)
            {
                Debug.Log($"{ _thisUnitCard.ThisUnitType} should not be of type: Character. Please check the Unit Type.");
                _isTypeVerified = false;
            }
        }
        else
        {
            _thisUnitCard = card;
            _isTypeVerified = true;
            _title = _thisUnitCard.Title;
            _cardNumber = _thisUnitCard.CardNumber;
            _cardText = _thisUnitCard.CardText;
            _rarity = _thisUnitCard.Rarity;
            _cardType = _thisUnitCard.ThisCardType;
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