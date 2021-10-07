﻿using UnityEngine;
using System;

/// <summary>
/// Assign this Scriptable Object to the specified field
/// in a Prefab with the <c>UnitCardGameObject</c> component.
/// </summary>
[CreateAssetMenu(menuName ="Card/Character Card")]
public class UnitCardObject: CardObject
{
    [SerializeField] private UnitCard _unitCard;
    public UnitCard ThisUnitCard
    {
        get => _unitCard;
        set
        {
           switch(_unitCard.ThisCardType)
            {
                case CardType.Action:
                case CardType.Location:
                case CardType.Upgrade:
                    Debug.Log($"{_unitCard.ThisCardType} should not be of type: UnitCard. Please check the Card Type.");
                   _isTypeVerified = false;
                    break;
                default:
                    _unitCard = value;
                   _isTypeVerified = true;
                    break;
            }
        }
    }
    
    protected override void OnValidate()
    {
        try
        {
          ThisUnitCard = _unitCard;
        }
        catch(NullReferenceException ex)
        {
            Debug.Log("Please assign a Unit Card to this game object.");
        }
        
    }
}