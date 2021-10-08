using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>LocationCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName = ("Card/ Location Card"))]
public class LocationCardObject : CardObject
{
    [SerializeField] private LocationCard _locationCard = new LocationCard();

    public LocationCard ThisLocationCard// ENCAPSULATION
    {
        get => _locationCard;
        set
        {
            if (_locationCard.ThisCardType != CardType.Location)
            {
                Debug.Log($"{_locationCard.ThisCardType} should not be of type: LocationCard. Please check the Card Type.");
                _isTypeVerified = false;
            }

            else
            {
                _locationCard = value;
                _isTypeVerified = true;
                _title = _locationCard.Title;
                _cardNumber = _locationCard.CardNumber;
            }
        }
    }
    protected override void OnValidate()
    {
        try
        {
            ThisLocationCard = _locationCard;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Please assign an Location Card to this game object.");
        }
    }
}
