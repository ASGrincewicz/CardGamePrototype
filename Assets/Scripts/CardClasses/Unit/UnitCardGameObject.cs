using UnityEngine;
using System;
/// <summary>
/// Used to represent Unit Cards during gameplay.
/// Must have <c>UnitCardObject</c> assigned
/// in order to function.
/// </summary>
public class UnitCardGameObject :CardGameObject// INHERITANCE
{
    [SerializeField] private UnitCardObject _unitCardSO;
    [SerializeField] private UnitCard _unitCard => _unitCardSO.ThisUnitCard;
    public UnitCardObject CardObject// ENCAPSULATION
    {
        get=> _unitCardSO;
        set
        {
            if (_unitCardSO.TypeVerified)
                _unitCardSO = value;
            else
            {
                Debug.Log("Please verify the UnitCardObject's type.");
            }
        }
    }
    #region Inherited Methods
    protected override void OnValidate()// POLYMORPHISM
    {
        try
        {
            if (!_unitCardSO.TypeVerified)
            {
                _unitCardSO = null;
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
            {
                _isCardVerified = true;
                if (this.gameObject.activeInHierarchy)
                    this.gameObject.name = $"{_unitCard.CardNumber}_{_unitCard.Title}_card";
                _cardBorder.color = _rarityColors[(int)_unitCard.Rarity];
                _cardImage.color = _cardClassColors[(int)_unitCard.ThisCardType];
                _cardText.text = $"{_unitCard.CardText}";
                _titleText.text = $"{_unitCard.Title}";
            }
        }
        catch(NullReferenceException ex)
        {
            if (this.gameObject.activeInHierarchy)
                Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }

    protected override void OnEnable()// POLYMORPHISM
    {
        try
        {
            if (_unitCardSO == null)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
                VerifyCardToPlay();// ABSTRACTION

        }
       
        catch (NullReferenceException ex)
        {
            Debug.Log($"You have not assigned a Unit Card Object to {gameObject.name}!");
        }
    }
   
    protected override void PlayCard()// POLYMORPHISM
    {
        Debug.Log($"{this.gameObject.name} was played.");
    }
    #endregion
}
