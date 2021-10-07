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
    private Dictionary<Card, int> _cardLibrary = new Dictionary<Card, int>();
    public Dictionary<Card, int> CardSet { get => _cardLibrary; set => _cardLibrary = value; }

    /// <summary>
    /// Adds a card to the Dictionary if it's not already listed.
    /// </summary>
    /// <param name="card"></param>
    /// <param name="cardNumber"></param>
    public void AddToCardLibrary(Card card, int cardNumber)
    {
        if (_cardLibrary.ContainsKey(card))
            Debug.Log("Already Exists");
        else
            _cardLibrary.Add(card, cardNumber);
    }
    /// <summary>
    /// Removes a card rom the Dictionary if the card is listed.
    /// </summary>
    /// <param name="cardName"></param>
    /// <param name="cardNumber"></param>
    public void RemoveCardFromLibrary(Card cardName, int cardNumber)
    {
        if (_cardLibrary.ContainsKey(cardName) && _cardLibrary.ContainsValue(cardNumber))
            _cardLibrary.Remove(cardName);
    }

    public void SaveCardLibrary()
    {
       // string json = JsonUtility.ToJson(library);
       // File.WriteAllText(Application.persistentDataPath + "/cardLibrary.json", json);
    }

    public void LoadCardLibrary(string path)
    {
        if(File.Exists(path))
        {
            //
        }
    }
}
