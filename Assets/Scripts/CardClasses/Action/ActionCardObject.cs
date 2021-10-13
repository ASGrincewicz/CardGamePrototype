using UnityEngine;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the ActionCardGameObject component.
/// </summary>
[CreateAssetMenu(menuName = "Card/Action Card")]
public class ActionCardObject: CardObject// INHERITANCE
{
    [SerializeField] protected ActionCard _thisActionCard;
    public ActionCard GetCard() => _thisActionCard;
    protected override void SetCard(ActionCard card)
    {
        if (_thisActionCard.ThisCardType != CardType.Action)
        {
            Debug.Log($"{_thisActionCard.ThisCardType} should not be of type: ActionCard. Please check the Card Type.");
            _isTypeVerified = false;
        }

        else
        {
            _thisActionCard = card;
            _isTypeVerified = true;
            _title = _thisActionCard.Title;
            _cardNumber = _thisActionCard.CardNumber;
            _cardText = _thisActionCard.CardText;
            _rarity = _thisActionCard.Rarity;
            _cardType = _thisActionCard.ThisCardType;
        }
    }
}
