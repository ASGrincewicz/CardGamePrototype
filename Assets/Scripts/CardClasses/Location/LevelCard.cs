using System;
using UnityEngine;
///<summary>
///The Class LevelCard is the base for :
///<list type="bullet">
///<item>Level</item>
/// </list>
///Direction is added to the required variables.
/// </summary>
[System.Serializable]
public class LevelCard: LocationCard
{
    /// <summary>
    /// Determines where this Level can connect to other Levels.
    /// </summary>
    [Flags]
    public enum Directions { Up, Down, Left, Right, All}
    [SerializeField] private Directions _availableDirections;
}


