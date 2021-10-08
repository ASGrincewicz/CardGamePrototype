using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Card Library")]
public class CardLibraryObject: ScriptableObject
{
     private CardLibrary _cardSet;
    public CardLibrary ThisCardLibrary
    {
        get => _cardSet;
        private set
        {
            if(_cardSet == null)
                _cardSet = new CardLibrary();
        }
    }
    
    [SerializeField] private string _filePath;

    [SerializeField] private List<CardObject> _cards = new List<CardObject>();


    private void OnValidate()
    {

        foreach (var card in _cards)
        {
            if (card.TypeVerified && !_cardSet.CardSet.ContainsKey(card.Title) && !_cardSet.CardSet.ContainsValue(card.CardNumber))
                _cardSet.AddToCardLibrary(card.Title, card.CardNumber);
            else if(!card.TypeVerified && _cardSet.CardSet.ContainsKey(card.Title) && _cardSet.CardSet.ContainsValue(card.CardNumber))
            {
                _cardSet.RemoveCardFromLibrary(card.Title, card.CardNumber);
                _cards.Remove(card);
            }
        }
        Debug.Log(_cardSet.CardSet.Count);
    }
}