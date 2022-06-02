//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase.Firestore;
//public class NftMetaDataCreater : MonoBehaviour
//{
//    public NftCatalogue characterData;
//    [SerializeField]
//    private string _characterPath="character_sheets/TestCharacter";
//    public void SendData() {
///*         var myCharacterData=new CharacterData
//        {
//            Name=  "GenftTest",
//            Discription="TestDiscriptionData",
//            Level="1"
//        }; */
///*         characterData.Name="GenftTest";
//        characterData.Discription="Testing data sync";
//        characterData.Level="01";
//        string json=JsonUtility.ToJson(characterData);
//        Debug.Log(json); */
//        var firestore=FirebaseFirestore.DefaultInstance;
//        firestore.Document(_characterPath).SetAsync(characterData.nftData);
//    }
//}
