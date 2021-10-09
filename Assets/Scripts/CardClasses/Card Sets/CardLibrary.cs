using System.Collections.Generic;
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
public class CardLibrary<K, V>
{
    [SerializeField] private string _setName = "Base Set";
   [SerializeField] private Dictionary<K, V> _cardLibrary = new ();
    public Dictionary<K, V> CardSet// ENCAPSULATION
    {
        get => _cardLibrary;
        set
        {
            if(_cardLibrary == null)
                _cardLibrary = new ();
        }
    }
    
    /// <summary>
    /// Adds a card to the Dictionary if it's not already listed.
    /// </summary>
    /// <param name="card"></param>
    /// <param name="cardNumber"></param>
    public void AddToCardLibrary(K t, V x)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(t))
        {
            Debug.Log("Already Exists");
        }
        else
        {
            _cardLibrary.Add(t, x);
            //Debug.Log($"{cardName} has been added.");
        }
    }
    /// <summary>
    /// Removes a card rom the Dictionary if the card is listed.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="cardNumber"></param>
    public void RemoveCardFromLibrary(K key, V value)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(key))
        {
            _cardLibrary.Remove(key);
            //Debug.Log($"{cardName} has been removed.");
        }
    }
    /// <summary>
    /// This Method checks the Card Set data for a matching name and number
    /// to verify the card is in the set.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    public bool ValidateCardInLibrary(K key, V value)// ABSTRACTION
    {
        if (_cardLibrary.ContainsKey(key))
            return true;
        else
            return false;
    }
}
