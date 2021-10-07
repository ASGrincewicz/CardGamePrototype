using UnityEngine;
/// <summary>
/// This class is inherited by other Card Game Object classes.
/// </summary>
public abstract class CardGameObject: MonoBehaviour
{
    [SerializeField] protected bool _isCardVerified;
    public bool CardVerified { get => _isCardVerified; private set => _isCardVerified = value; }

    protected abstract void OnValidate();
    protected abstract void OnEnable();
    /// <summary>
    /// This Method should be called to play a card, rather than PlayCard();
    /// </summary>
    protected void VerifyCardToPlay()
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
