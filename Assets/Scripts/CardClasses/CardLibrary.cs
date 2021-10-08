using System.Collections.Generic;
using System.IO;
using UnityEngine;


/// <summary>
/// CardLibrary is responsible for
/// keeping track of created cards.
/// <list type="bullet">
/// <listheader><b>Public Methods</b></listheader>
/// <list type="bullet"><item>AddToCardLibrary</item>
/// <item>RemoveCardFromLibrary</item>
/// </list>
/// </list>
/// </summary>

[System.Serializable]
public class CardLibrary
{
    [SerializeField] private string _setName = "Base Set";
   [SerializeField] private Dictionary<string, int> _cardLibrary = new Dictionary<string, int>();
    public Dictionary<string, int> CardSet// ENCAPSULATION
    {
        get => _cardLibrary;
        set
        {
            if(_cardLibrary == null)
                _cardLibrary = new Dictionary<string, int>();
        }
    }
    
    /// <summary>
    /// Adds a card to the Dictionary if it's not already listed.
    /// </summary>
    /// <param name="card"></param>
    /// <param name="cardNumber"></param>
    public void AddToCardLibrary(string cardName, int cardNumber)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(cardName))
        {
            Debug.Log("Already Exists");
        }
        else
        {
            _cardLibrary.Add(cardName, cardNumber);
            Debug.Log($"{cardName} has been added.");
        }
    }
    /// <summary>
    /// Removes a card rom the Dictionary if the card is listed.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="cardNumber"></param>
    public void RemoveCardFromLibrary(string cardName, int cardNumber)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(cardName))
        {
            _cardLibrary.Remove(cardName);
            Debug.Log($"{cardName} has been removed.");
        }
    }
    /// <summary>
    /// This Method checks the Card Set data for a matching name and number
    /// to verify the card is in the set.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    public bool ValidateCardInLibrary(string cardName, int cardNumber)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(cardName))
            return true;
        else
            return false;
    }
}
