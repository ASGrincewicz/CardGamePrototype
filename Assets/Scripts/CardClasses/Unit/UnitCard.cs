using UnityEngine;
///<summary>
///The Class <c>UnitCard</c> is the base for :
///<list type="bullet">
///<item>Character</item>
///<item>Creature</item>
///<item>Enemy</item>
///<item>Boss</item>
/// </list>
/// Hit Points and Power
/// are added to the required variables.
/// Designers must also specify a Unit Type.
/// </summary>
[System.Serializable]
public class UnitCard: Card// INHERITANCE
{
    [SerializeField] protected UnitType _unitType;
    [SerializeField] protected int _hitPoints = 0;
    [SerializeField] protected int _power = 0;
   public UnitType ThisUnitType
    {
        get => _unitType;
        protected set
        {
            if (_cardType == CardType.Unit)
                _unitType = value;
            else
                return;
        }
    }
    public new CardType ThisCardType
    {
        get => _cardType;
        set
        {
            switch (_cardType)
            {
                case CardType.Action:
                case CardType.Location:
                case CardType.Upgrade:
                    Debug.Log($"{_cardType} should not be of type: UnitCard. Please check the Card Type.");
                    break;
                default:
                    _cardType = value;
                    break;
            }
        }
    }
}

