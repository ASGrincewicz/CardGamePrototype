using UnityEngine;
using System;
/// <summary>
/// Used to represent Upgrade Cards during gameplay.
/// Must have <c>UpgradeCardObject</c> assigned
/// in order to function.
/// </summary>
public class UpgradeCardGameObject: CardGameObject// INHERITANCE
{
    [SerializeField] private UpgradeCardObject _upgradeCardSO;
    [SerializeField] private UpgradeCard _upgradeCard => _upgradeCardSO.ThisUpgradeCard;
    public UpgradeCardObject CardObject// ENCAPSULATION
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
    protected override void OnValidate()// POLYMORPHISM
    {
        try
        {
            if (!_upgradeCardSO.TypeVerified)
            {
                _upgradeCardSO = null;
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
            {
                if (this.gameObject.activeInHierarchy)
                    this.gameObject.name = $"{_upgradeCard.CardNumber}_{_upgradeCard.Title}_card";
                _isCardVerified = true;
                _cardBorder.color = _rarityColors[(int)_upgradeCard.Rarity];
                _cardImage.color = _cardClassColors[(int)_upgradeCard.ThisCardType];
                _cardText.text = $"{_upgradeCard.CardText}";
                _titleText.text = $"{_upgradeCard.Title}";
            }
        }
        catch (NullReferenceException ex)
        {
            if (this.gameObject.activeInHierarchy)
                Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }

    protected override void OnEnable()// POLYMORPHISM
    {
        try
        {
            if (_upgradeCardSO == null)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
                VerifyCardToPlay();// ABSTRACTION
        }

        catch (NullReferenceException ex)
        {
            Debug.Log($"You have not assigned an Upgrade Card Object to {gameObject.name}!");
        }
    }

    protected override void PlayCard()// POLYMORPHISM
    {
        Debug.Log($"{this.gameObject.name} was played.");
    }
    #endregion
}
