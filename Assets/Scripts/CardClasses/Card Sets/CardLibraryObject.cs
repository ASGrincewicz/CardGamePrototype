using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Card Library")]
public class CardLibraryObject<T>: ScriptableObject
{
     private CardLibrary<string, int> _cardSet;
    public CardLibrary<string, int> ThisCardLibrary// ENCAPSULATION
    {
        get => _cardSet;
        private set
        {
            if(_cardSet == null)
                _cardSet = new ();
        }
    }
    
    [SerializeField] private List<CardObject<Card<T>>> _cards = new();


    private void OnValidate()
    {
        if (_cardSet == null)
            _cardSet = new ();
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