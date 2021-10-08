using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// This class is inherited by other Card Game Object classes.
/// </summary>
public abstract class CardGameObject: MonoBehaviour// INHERITANCE
{
    [SerializeField] protected bool _isCardVerified;
    [SerializeField] protected TMP_Text _titleText;
    [SerializeField] protected TMP_Text _cardText;
    [SerializeField] protected Image _cardBorder;
    [SerializeField] protected Image _cardImage;
    [SerializeField] protected Color[] _rarityColors = new Color[4];
    [SerializeField] protected Color[] _cardClassColors = new Color[7];
    public bool CardVerified { get => _isCardVerified; private set => _isCardVerified = value; }

    protected abstract void OnValidate();// INHERITANCE
    protected abstract void OnEnable();// INHERITANCE
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
    /// <summary>
    /// You should call <c>VerifyCardToPlay()</c> to play a card.
    /// This method executes gameplay and functionality for a card.
    /// </summary>
    protected abstract void PlayCard();
    
}
