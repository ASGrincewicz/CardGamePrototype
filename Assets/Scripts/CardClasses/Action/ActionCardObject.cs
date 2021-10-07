using UnityEngine;
using System;
/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>ActionCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName = "Card/Action Card")]
public class ActionCardObject: CardObject
{ 
    [SerializeField] private ActionCard _actionCard = new ActionCard();

    public ActionCard ThisActionCard
    {
        get => _actionCard;
        set
        {
            if (_actionCard.ThisCardType != CardType.Action)
            {
                Debug.Log($"{_actionCard.ThisCardType} should not be of type: ActionCard. Please check the Card Type.");
                _isTypeVerified = false;
            }
           
            else
            {
                _actionCard = value;
                _isTypeVerified = true;
            }
        }
    }
    protected override void OnValidate()
    {
        try
        {
            ThisActionCard = _actionCard;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Please assign a Upgrade Card to this game object.");
        }
    }

}
