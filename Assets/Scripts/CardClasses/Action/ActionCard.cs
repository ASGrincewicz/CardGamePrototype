///<summary>
///The Class <c>ActionCard</c> is the base for :
///<list type="bullet">
///<item>Action</item>
/// </list>
/// </summary>
[System.Serializable]
public class ActionCard: Card// INHERITANCE
{
    public CardType ThisCardType { get => _cardType; private set => _cardType = CardType.Action; }// ENCAPSULATION
}

