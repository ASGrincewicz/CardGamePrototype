using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private GameObject[] _playerZones = new GameObject[4];
    [SerializeField] private GameObject[] _cardSpots = new GameObject[28];

    [SerializeField] private CardLibraryObject _cardSet;
}
