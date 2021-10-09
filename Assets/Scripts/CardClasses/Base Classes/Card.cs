using UnityEngine;
///<summary>
///<c>Card</c> is the base class for all card types.
///All cards should have:
///<list type="bullet">
///<item>Card Set</item>
///<item>Title</item>
///<item>Card Type</item>
///<item>Card Number</item>
///<item>Card Rarity</item>
///<item>Card Text</item>
///<item>Image Sprite</item>
///</list>
/// </summary>
[System.Serializable]
public class Card<T>
{
    [SerializeField] protected CardLibraryObject _cardSet;
    [SerializeField] protected string _title = "Card Title";
    [SerializeField] protected CardType _cardType;
    [SerializeField] protected int _cardNumber = 0;
    [SerializeField] protected CardRarity _rarity = CardRarity.Common;
    [Multiline] [SerializeField] protected string _cardText = "Card Text";
    [SerializeField] protected Sprite _cardImageSprite = null;
    public CardLibraryObject CardSet// ENCAPSULATION
    {
        get => _cardSet;
        private set
        {
            if (_cardSet.ThisCardLibrary.ValidateCardInLibrary(_title, _cardNumber))
                _cardSet = value;
            else
            {
                _cardSet = null;
                Debug.LogWarning("This Set does not contain the specific card. Check the card details.");
            }
        }
    }
    public string Title { get => _title; set => _title = value; }
    public int CardNumber// ENCAPSULATION
    {
        get => _cardNumber;
        set
        {
            if (_cardNumber <= 0)
                Debug.Log("Card number invalid. Please use an integer greater than 0.");
            else
                _cardNumber = value;
        }
    }
    public CardRarity Rarity { get => _rarity; }// ENCAPSULATION
    public string CardText { get => _cardText; set => _cardText = value; }// ENCAPSULATION
    public CardType ThisCardType { get => _cardType; protected set => _cardType = value; }
}
