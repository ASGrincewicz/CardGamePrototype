using UnityEngine;
using System;
/// <summary>
/// Used to represent Upgrade Cards during gameplay.
/// Must have <c>UpgradeCardObject</c> assigned
/// in order to function.
/// </summary>
public class UpgradeCardGameObject: CardGameObject
{
    [SerializeField] private UpgradeCardObject _upgradeCardSO;
    [SerializeField] private UpgradeCard _upgradeCard => _upgradeCardSO.ThisUpgradeCard;
    public UpgradeCardObject CardObject
    {
        get => _upgradeCardSO;
        set
        {
            if (_upgradeCardSO.TypeVerified)
                _upgradeCardSO = value;
            else
                Debug.Log("Please verify the UpgradeCardObject's type.");
        }
    }
    #region Inherited Methods
    protected override void OnValidate()
    {
        try
        {
            if (!_upgradeCardSO.TypeVerified)
            {
                _upgradeCardSO = null;
                throw new NullReferenceException();
            }
            else
            {
                this.gameObject.name = $"{_upgradeCard.CardNumber}_{_upgradeCard.Title}_card";
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }

    protected override void OnEnable()
    {
        if (_upgradeCardSO == null)
            Debug.Log("You have not assigned an Upgrade Card Object!");
    }

    protected override void PlayCard()
    {
       //
    }
    #endregion
}
