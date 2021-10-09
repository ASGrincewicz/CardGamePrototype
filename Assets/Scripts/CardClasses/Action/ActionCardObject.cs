using UnityEngine;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the ActionCardGameObject component.
/// </summary>
[CreateAssetMenu(menuName = "Card/Action Card")]
public class ActionCardObject: CardObject<ActionCard>// INHERITANCE
{
    //[SerializeField] protected new ActionCard _thisCard;
    
    protected override void SetCard(Card<ActionCard> card)
    {
        if (_thisCard.ThisCardType != CardType.Action)
        {
            Debug.Log($"{_thisCard.ThisCardType} should not be of type: ActionCard. Please check the Card Type.");
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
