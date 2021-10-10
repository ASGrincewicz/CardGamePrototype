using UnityEngine;
/// <summary>
/// This class is inherited by the Main Card Classes.
/// </summary>
public class CardObject: ScriptableObject
{
    protected string _title;
    protected int _cardNumber;
    protected string _cardText;
    protected CardRarity _rarity;
    protected CardType _cardType;
    [SerializeField] protected bool _isTypeVerified;
    public bool TypeVerified { get => _isTypeVerified; private set => _isTypeVerified = value; }// ENCAPSULATION
    public string Title { get => _title; private set => _title = value; }// ENCAPSULATION
    public int CardNumber { get => _cardNumber; private set => _cardNumber = value; }
    public string CardText { get => _cardText; private set => _cardText = value; }
    public CardRarity Rarity { get => _rarity; private set => _rarity = value; }
    public CardType ThisCardType { get => _cardType; private set => _cardType = value; }
    //public Card<Card> GetCard() => _thisCard;
    protected virtual void SetCard(Card card) { }
    protected virtual void SetCard(UnitCard card) { }
    protected virtual void SetCard(UpgradeCard card) { }
    protected virtual void SetCard(ActionCard card) { }
    protected virtual void SetCard(LocationCard card) { }
    //protected virtual void SetCard(LevelCard card) { }
}
