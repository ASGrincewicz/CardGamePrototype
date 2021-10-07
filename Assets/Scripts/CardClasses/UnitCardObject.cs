using UnityEngine;

[CreateAssetMenu(menuName ="Card/Character Card")]
public class UnitCardObject: ScriptableObject
{
    [SerializeField] private UnitCard _characterCard = new UnitCard();
}