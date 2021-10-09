using UnityEngine;

///<summary>
///The Class LocationCardis the base for :
///<list type="bullet">
///<item>Location</item>
//////<item>Level</item>
/// </list>
///Environment Type and Climate Temp
/// are added to the required variables.
/// </summary>
[System.Serializable]
public class LocationCard: Card<LocationCard>
{
    [SerializeField] protected EnvironmentType _environmentType;
    [SerializeField] protected ClimateTemp _climateTemp;
    public new CardType ThisCardType { get => _cardType; private set => _cardType = CardType.Location; }// ENCAPSULATION
    public EnvironmentType ThisEnvironMentType
    {
        get => _environmentType;
        private set
        {
            if (value == EnvironmentType.Space && _climateTemp != ClimateTemp.Vaccuum)
                _climateTemp = ClimateTemp.Vaccuum;
            else
                _environmentType = value;
        }
    }
    public ClimateTemp ThisClimateTemp
    {
        get => _climateTemp;
        private set
        {
            if (value == ClimateTemp.Vaccuum && _environmentType != EnvironmentType.Space)
                _environmentType = EnvironmentType.Space;
            else
                _climateTemp = value;
        }
    }

}


