using UnityEngine;

///<summary>
///The Class <c>UpgradeCard</c> is the base for :
///<list type="bullet">
///<item>Upgrade</item>
/// </list>
///You must set the UpgradeType enum, and power if UpgradeType is Weapon.
/// </summary>
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
       private set
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
    public CardType ThisCardType { get => _cardType; private set => _cardType = CardType.Upgrade; }
   

    public UpgradeType ThisUpgradeType
    {
        get => _upgradeType;
        private set
        {
            if(_power > 0 && _upgradeType == UpgradeType.Tech)
                Debug.Log($"Power is currently set to {_power}. Please verify the Upgrade Type. ");
            else
                _upgradeType = value;
        }
    }

    private void OnValidate()
    {
        ThisUpgradeType = _upgradeType;
        ThisCardType = _cardType;
        Power = _power;
    }
}

