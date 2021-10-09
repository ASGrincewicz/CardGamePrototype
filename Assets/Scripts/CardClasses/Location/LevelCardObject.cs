using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the LevelCardGameObject component.
/// </summary>
[CreateAssetMenu(menuName = "Card/Level")]
public class LevelCardObject : CardObject<LevelCard>
{
    //[SerializeField] protected new LevelCard _thisCard;
    protected override void SetCard(Card<LevelCard> card)
    {
        if (_thisCard.ThisCardType != CardType.Location)
        {
            Debug.Log($"{_thisCard.ThisCardType} should not be of type: LevelCard. Please check the Card Type.");
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
