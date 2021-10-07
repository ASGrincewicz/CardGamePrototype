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
                _actionCardSO = null;
                throw new NullReferenceException();
            }
            else
            {
                this.gameObject.name = $"{_actionCard.CardNumber}_{_actionCard.Title}_card";
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }

    protected override void OnEnable()
    {
        if (_actionCardSO == null)
            Debug.Log("You have not assigned an Action Card Object!");
    }

    protected override void PlayCard()
    {
        //
    }
    #endregion
}