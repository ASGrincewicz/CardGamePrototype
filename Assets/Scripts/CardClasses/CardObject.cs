using UnityEngine;

/// <summary>
/// This class is inherited by the Main Card Classes.
/// </summary>
public abstract class CardObject: ScriptableObject
{
    [SerializeField] protected bool _isTypeVerified;

    public bool TypeVerified { get => _isTypeVerified; private set => _isTypeVerified = value; }
    protected abstract void OnValidate();
}
