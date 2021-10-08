using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Card Library")]
public class CardLibraryObject: ScriptableObject
{
     private CardLibrary _cardSet;
    public CardLibrary ThisCardLibrary// ENCAPSULATION
    {
        get => _cardSet;
        private set
        {
            if(_cardSet == null)
                _cardSet = new CardLibrary();
        }
    }
    
    [SerializeField] private List<CardObject> _cards = new List<CardObject>();


    private void OnValidate()
    {
        if (_cardSet == null)
            _cardSet = new CardLibrary();
        foreach (var card in _cards)
        {
            if (card.TypeVerified && !_cardSet.CardSet.ContainsKey(card.Title) && !_cardSet.CardSet.ContainsValue(card.CardNumber))
                _cardSet.AddToCardLibrary(card.Title, card.CardNumber);
            else
            {
                _cardSet.RemoveCardFromLibrary(card.Title, card.CardNumber);
            }
        }
        Debug.Log(_cardSet.CardSet.Count);
    }
}