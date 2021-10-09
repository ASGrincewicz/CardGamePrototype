using UnityEngine;
using System;

/// <summary>
/// This class is inherited by the Main Card Classes.
/// </summary>
public class CardObject<Card>: ScriptableObject
{
    protected string _title;
    protected int _cardNumber;
    [SerializeField] protected bool _isTypeVerified;
    protected Card<Card> _thisCard;
    public bool TypeVerified { get => _isTypeVerified; private set => _isTypeVerified = value; }// ENCAPSULATION
    public string Title { get => _title; private set => _title = value; }// ENCAPSULATION
    public int CardNumber { get => _cardNumber; private set => _cardNumber = value; }// ENCAPSULATION
    public Card<Card> GetCard() => _thisCard;
    protected virtual void SetCard(Card<Card> card) => _thisCard = card;
    //protected virtual void SetCard(UnitCard card) { }
    protected virtual void SetCard(UpgradeCard card) { }
    //protected virtual void SetCard(ActionCard card) { }
    //protected virtual void SetCard(LocationCard card) { }
    //protected virtual void SetCard(LevelCard card) { }
    protected virtual void OnValidate()
    {
        try
        {
            SetCard(_thisCard);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log($"Please assign a {_thisCard.ThisCardType} card to this game object.");
        }
    }
}
