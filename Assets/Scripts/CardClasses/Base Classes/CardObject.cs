using UnityEngine;

/// <summary>
/// This class is inherited by the Main Card Classes.
/// </summary>
public abstract class CardObject: ScriptableObject
{
    protected string _title;
    protected int _cardNumber;
    [SerializeField] protected bool _isTypeVerified;

    public bool TypeVerified { get => _isTypeVerified; private set => _isTypeVerified = value; }// ENCAPSULATION
    public string Title { get => _title; private set => _title = value; }// ENCAPSULATION
    public int CardNumber { get => _cardNumber; private set => _cardNumber = value; }// ENCAPSULATION
    protected abstract void OnValidate();
}
