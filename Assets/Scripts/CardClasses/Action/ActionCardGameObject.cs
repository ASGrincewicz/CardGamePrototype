using UnityEngine;
using System;
/// <summary>
/// Used to represent Upgrade Cards during gameplay.
/// Must have <c>ActionCardObject</c> assigned
/// in order to function.
/// </summary>
public class ActionCardGameObject: CardGameObject
{

    [SerializeField] private ActionCardObject _actionCardSO;
    [SerializeField] private ActionCard _actionCard => _actionCardSO.ThisActionCard;
    public ActionCardObject CardObject
    {
        get => _actionCardSO;
        set
        {
            if (_actionCardSO.TypeVerified)
                _actionCardSO = value;
            else
            {
                Debug.Log("Please verify the ActionCardObject's type.");
            }
        }
    }
    #region Inherited Methods
    protected override void OnValidate()
    {
        try
        {
            if (!_actionCardSO.TypeVerified)
            {
                _isCardVerified = false;
                _actionCardSO = null;
                throw new NullReferenceException();
            }
            else
            {
                this.gameObject.name = $"{_actionCard.CardNumber}_{_actionCard.Title}_card";
                _isCardVerified = true;
                _cardBorder.color = _rarityColors[(int)_actionCard.Rarity];
                _cardImage.color = _cardClassColors[(int)_actionCard.ThisCardType];
                _cardText.text = $"{_actionCard.CardText}";
                _titleText.text = $"{_actionCard.Title}";
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }

    protected override void OnEnable()
    {
        try
        {
            if (_actionCardSO == null)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
                VerifyCardToPlay();

        }

        catch (NullReferenceException ex)
        {
            Debug.Log($"You have not assigned an Action Card Object to {gameObject.name}!");
        }
    }

    protected override void PlayCard()
    {
        Debug.Log($"{this.gameObject.name} was played.");
    }
    #endregion
}