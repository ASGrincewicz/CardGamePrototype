using UnityEngine;
///<summary>
///The Class <c>ActionCard</c> is the base for :
///<list type="bullet">
///<item>Action</item>
/// </list>
/// </summary>
[System.Serializable]
public class ActionCard: Card
{
    public CardType ThisCardType
    {
        get => _cardType;
        set
        {
            if(_cardType != CardType.Action)
                Debug.Log($"{_cardType} should not be of type: ActionCard. Please check the Card Type.");
            else
                _cardType = value;
        }
    }
}

