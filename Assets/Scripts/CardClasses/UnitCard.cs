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
/// </summary>
[System.Serializable]
public class UnitCard: Card
{
    [SerializeField] private int _hitPoints = 0;
    [SerializeField] private int _power = 0;
   
    public CardType ThisCardType
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



[System.Serializable]
public class UpgradeCard: Card
{
    public enum UpgradeType
    {
        Tech,
        Weapon
    }
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private int _power = 0;
    public int Power
    {
        get => _power;
        set
        {
            if (_upgradeType != UpgradeType.Weapon)
            {
                _power = 0;
                Debug.Log("Only Weapon Upgrades need a power > 0");
            }
            else
                _power = value;
        }
    }
    public CardType ThisCardType
    {
        get => _cardType;
        set
        {
           if(_cardType != CardType.Upgrade)
                    Debug.Log($"{_cardType} should not be of type: UpgradeCard. Please check the Card Type.");
            else
               _cardType = value;
        }
    }
}

