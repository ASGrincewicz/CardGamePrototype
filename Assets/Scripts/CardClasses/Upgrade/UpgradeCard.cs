using UnityEngine;

///<summary>
///The Class <c>UpgradeCard</c> is the base for :
///<list type="bullet">
///<item>Upgrade</item>
/// </list>
///You must set the UpgradeType enum, and power if UpgradeType is Weapon.
/// </summary>
[System.Serializable]
public class UpgradeCard: Card// INHERITANCE
{
    public enum UpgradeType
    {
        Tech,
        Weapon
    }
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private int _power = 0;
    public int Power// ENCAPSULATION
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
    public new CardType ThisCardType
    {
        get => _cardType;
        private set
        {
            if (value != CardType.Upgrade)
            {
                Debug.Log("Changing this variable will result in errors.");
                value = CardType.Upgrade;
                _cardType = value;
            }
               
            else
                _cardType = CardType.Upgrade;
        }// ENCAPSULATION
    }
   

    public UpgradeType ThisUpgradeType// ENCAPSULATION
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
}

