using UnityEngine;
using System.IO;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Card Library")]
public class CardLibraryObject: ScriptableObject
{
     private CardLibrary _cardSet = new CardLibrary();
    
    [SerializeField] private string _filePath;



    private void OnEnable()
    {
       
    }

}