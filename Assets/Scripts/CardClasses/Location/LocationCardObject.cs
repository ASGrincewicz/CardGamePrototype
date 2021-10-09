﻿using UnityEngine;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the LocationCardGameObject component.
/// </summary>
[CreateAssetMenu(menuName = ("Card/ Location Card"))]
public class LocationCardObject : CardObject<LocationCard>
{
    //[SerializeField] protected new LocationCard _thisCard;
    protected override void SetCard(Card<LocationCard> card)
    {
        if (_thisCard.ThisCardType != CardType.Location)
        {
            Debug.Log($"{_thisCard.ThisCardType} should not be of type: LocationCard. Please check the Card Type.");
            _isTypeVerified = false;
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
