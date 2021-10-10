using UnityEngine;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the LocationCardGameObject component.
/// </summary>
[CreateAssetMenu(menuName = ("Card/ Location Card"))]
public class LocationCardObject : CardObject
{
    [SerializeField] protected LocationCard _thisLocationCard;
    public LocationCard GetCard() => _thisLocationCard;
    protected override void SetCard(LocationCard card)
    {
        if (_thisLocationCard.ThisCardType != CardType.Location)
        {
            Debug.Log($"{_thisLocationCard.ThisCardType} should not be of type: LocationCard. Please check the Card Type.");
            _isTypeVerified = false;
        }

        else
        {
            _thisLocationCard = card;
            _isTypeVerified = true;
            _title = _thisLocationCard.Title;
            _cardNumber = _thisLocationCard.CardNumber;
            _cardText = _thisLocationCard.CardText; 
        }
    }
}
