using UnityEngine;

/// <summary>
/// This class is inherited by the Main Card Classes.
/// </summary>
public abstract class CardObject: ScriptableObject
{
    protected string _title;
    protected int _cardNumber;
    [SerializeField] protected bool _isTypeVerified;

    public bool TypeVerified { get => _isTypeVerified; private set => _isTypeVerified = value; }
    public string Title { get => _title; private set => _title = value; }
    public int CardNumber { get => _cardNumber; private set => _cardNumber = value; }
    protected abstract void OnValidate();
}
