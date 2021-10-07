using UnityEngine;
using System;
/// <summary>
/// Used to represent Upgrade Cards during gameplay.
/// Must have <c>UpgradeCardObject</c> assigned
/// in order to function.
/// </summary>
public class UpgradeCardGameObject: MonoBehaviour
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
            {
                Debug.Log("Please verify the UnitCardObject's type.");
            }
        }
    }

    private void OnValidate()
    {
        try
        {
            if (!_upgradeCardSO.TypeVerified)
            {
                _upgradeCardSO = null;
                throw new NullReferenceException();
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogWarning($"Please check the card assigned is setup correctly.");
        }
    }

    private void OnEnable()
    {
        if (_upgradeCardSO == null)
            Debug.Log("You have not assigned a Unit Card Object!");
    }
}