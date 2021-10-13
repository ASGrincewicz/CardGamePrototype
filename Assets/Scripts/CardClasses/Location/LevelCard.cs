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
    /// Specifies the parent Location like a Planet, or Space Station.
    /// The Level climate and environment types
    /// must be compatible with the Location.
    /// </summary>
    [SerializeField] private LocationCard _currentLocation;
    /// <summary>
    /// Determines where this Level can connect to other Levels.
    /// Levels can have multiple available directions.
    /// </summary>
    [Flags]
    public enum Directions { Up, Down, Left, Right, All}
    [SerializeField] private Directions _availableDirections;

    public LocationCard CurrentLocation
    {
        get => _currentLocation;
        private set
        {
            if (value.ThisEnvironMentType == _environmentType && value.ThisClimateTemp == _climateTemp)
                _currentLocation = value;
            else
            {
                Debug.Log("Please check the stats on the Location Card.");
                _currentLocation = null;
            }
        }
    }
    public Directions AvailableDirections{get => _availableDirections; private set => _availableDirections = value; }
}


