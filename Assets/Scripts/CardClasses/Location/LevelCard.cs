using UnityEngine;
///<summary>
///The Class <c>LevelCard</c> is the base for :
///<list type="bullet">
///<item>Level</item>
/// </list>
///Direction is added to the required variables.
/// </summary>
[System.Serializable]
public class LevelCard: LocationCard
{
    public enum Directions { Up, Down, Left, Right}
    [SerializeField] private Directions _availableDirections;
}


