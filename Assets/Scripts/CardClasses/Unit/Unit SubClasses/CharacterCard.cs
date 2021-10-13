using UnityEngine;
///<summary>
///The Class CharacterCard
///adds UpgradeCard Slots to this UnitCard type.
/// </summary>
[System.Serializable]
public class CharacterCard : UnitCard
{
    [SerializeField] [Range(1, 5)] private int _upgradeSlots = 2;
    [SerializeField] private UpgradeCard[] _upgrades;

    private void OnAwake()
    {
        _upgrades = new UpgradeCard[_upgradeSlots];
    }
}

