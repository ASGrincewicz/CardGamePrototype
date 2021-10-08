using System.Collections;
using System.Collections.Generic;
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
public class Card
{
    [SerializeField] protected CardLibraryObject _cardSet;
    public CardLibraryObject CardSet
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
    [SerializeField] protected string _title = "Card Title";
    public string Title { get => _title; set => _title = value; }
    [SerializeField] protected CardType _cardType;
    [SerializeField] protected int _cardNumber = 0;
    public int CardNumber
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
    [SerializeField] protected CardRarity _rarity = CardRarity.Common;
    public CardRarity Rarity { get => _rarity; }
    [Multiline] [SerializeField] protected string _cardText = "Card Text";
    public string CardText { get => _cardText; set => _cardText = value; }
    [SerializeField] protected Sprite _cardImageSprite = null;
}
