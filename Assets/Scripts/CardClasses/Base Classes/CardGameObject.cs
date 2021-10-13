using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/// <summary>
/// This class is inherited by other Card Game Object classes.
/// </summary>
public class CardGameObject : MonoBehaviour// INHERITANCE
{
    [SerializeField] protected CardObject _cardSO;
    [SerializeField] protected bool _isCardVerified;
    [SerializeField] protected TMP_Text _titleText;
    [SerializeField] protected TMP_Text _cardText;
    [SerializeField] protected Image _cardBorder;
    [SerializeField] protected Image _cardImage;
    [SerializeField] protected Color[] _rarityColors = new Color[4];
    [SerializeField] protected Color[] _cardTypeColors = new Color[4];
   
    public bool CardVerified { get => _isCardVerified; private set => _isCardVerified = value; }
    public CardObject CardObject// ENCAPSULATION
    {
        get => _cardSO;
        set
        {
            if (_cardSO.TypeVerified)
                _cardSO = value;
            else
            {
                Debug.Log("Please verify the UnitCardObject's type.");
            }
        }
    }
    protected virtual void OnValidate()
    {
        try
        {
            if (!_cardSO.TypeVerified)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
            {
                _isCardVerified = true;
                if (this.gameObject.activeInHierarchy)
                    this.gameObject.name = $"{_cardSO.CardNumber}_{_cardSO.Title}_card";

                SetColors((int)_cardSO.ThisCardType);
                SetText();
            }
        }
        catch (NullReferenceException ex)
        {
            if (this.gameObject.activeInHierarchy)
                Debug.LogWarning($"Please check the card assigned to {name} is setup correctly.");
        }
    }// INHERITANCE
    protected virtual void OnEnable()
    {
        try
        {
            if (_cardSO == null)
            {
                _isCardVerified = false;
                throw new NullReferenceException();
            }
            else
                VerifyCardToPlay();// ABSTRACTION

        }

        catch (NullReferenceException ex)
        {
            Debug.Log($"You have not assigned a {_cardSO.ThisCardType} game object to {gameObject.name}!");
        }
    }// INHERITANCE
    protected virtual void SetColors(int typeColor)
    {
        _cardBorder.color = _rarityColors[(int)_cardSO.Rarity];
        _cardImage.color = _cardTypeColors[typeColor];
    }
    protected virtual void SetText()
    {
        _cardText.text = $"{_cardSO.CardText}";
        _titleText.text = $"{_cardSO.Title}";
    }
    /// <summary>
    /// You should call <para>VerifyCardToPlay()</para> to play a card.
    /// This method executes gameplay and functionality for a card.
    /// </summary>
    protected virtual void PlayCard()=> Debug.Log($"{this.gameObject.name} was played.");
    /// <summary>
    /// This Method should be called to play a card, rather than PlayCard();
    /// </summary>
    protected void VerifyCardToPlay()// ABSTRACTION
    {
        if (_isCardVerified)
        {
            PlayCard();
        }
        else
        {
            Debug.LogWarning("This card cannot be played. Check it's assigned card object for errors.");
            return;
        }
    }
}
