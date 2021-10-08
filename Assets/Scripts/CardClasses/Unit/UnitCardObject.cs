using UnityEngine;
using System;

/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UnitCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Unit Card")]
public class UnitCardObject: CardObject// INHERITANCE
{
    [SerializeField] private UnitCard _unitCard;
    public UnitCard ThisUnitCard// ENCAPSULATION
    {
        get => _unitCard;
        set
        {
           switch(_unitCard.ThisCardType)
            {
                case CardType.Action:
                case CardType.Location:
                case CardType.Upgrade:
                    Debug.Log($"{_unitCard.ThisCardType} should not be of type: UnitCard. Please check the Card Type.");
                   _isTypeVerified = false;
                    break;
                default:
                    _unitCard = value;
                   _isTypeVerified = true;
                    _title = _unitCard.Title;
                    _cardNumber = _unitCard.CardNumber;
                    break;
            }
        }
    }
    
    protected override void OnValidate()
    {
        try
        {
          ThisUnitCard = _unitCard;
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("Please assign a Unit Card to this game object.");
        }
        
    }
}
