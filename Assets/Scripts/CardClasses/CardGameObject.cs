using UnityEngine;
/// <summary>
/// This class is inherited by other Card Game Object classes.
/// </summary>
public abstract class CardGameObject: MonoBehaviour
{
    protected abstract void OnValidate();
    protected abstract void OnEnable();
    protected abstract void PlayCard();
}
