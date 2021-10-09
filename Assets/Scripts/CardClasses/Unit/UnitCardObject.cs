using UnityEngine;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UnitCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Unit Card")]
public class UnitCardObject: CardObject<UnitCard>// INHERITANCE
{
    //[SerializeField] protected new UnitCard _thisCard;
    protected override void SetCard(Card<UnitCard> card)
    {
        switch (_thisCard.ThisCardType)
        {
            case CardType.Action:
            case CardType.Location:
            case CardType.Upgrade:
                Debug.Log($"{_thisCard.ThisCardType} should not be of type: UnitCard. Please check the Card Type.");
                _isTypeVerified = false;
                break;
            default:
                _thisCard = card;
                _isTypeVerified = true;
                _title = _thisCard.Title;
                _cardNumber = _thisCard.CardNumber;
                break;
        }
    }
}
