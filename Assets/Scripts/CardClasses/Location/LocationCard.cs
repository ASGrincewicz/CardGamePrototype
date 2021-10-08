using UnityEngine;
///<summary>
///The Class <c>LocationCard</c> is the base for :
///<list type="bullet">
///<item>Location</item>
//////<item>Level</item>
/// </list>
///Environment Type and Climate Temp
/// are added to the required variables.
/// </summary>
[System.Serializable]
public class LocationCard: Card
{
    [SerializeField] private EnvironmentType _environmentType;
    [SerializeField] private ClimateTemp _climateTemp;
}


