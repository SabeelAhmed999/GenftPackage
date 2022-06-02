using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Storage;
using System;
using Newtonsoft.Json;
using Genft;
public class NftMetaDataUploader : MonoBehaviour
{
    public NftMinter nftMinter;
    public Texture2D texture2D;
    [System.Serializable]
    public class NftData
    {
        public string dna;
        public string name;
        public string description;
        public string image;
        public Dictionary<string, string> attributes = new Dictionary<string, string>()
        {
              {"trait_type", "Level"},
              {"value", "1"}
        };

    }
    public NftData nftMetaData;
    public void UploadNftImage()
    {
        
        StartCoroutine(UploadCoroutine(texture2D, nftMetaData));
    }
    private IEnumerator UploadCoroutine(Texture2D nftImage, NftData data)
    {
        var storage = FirebaseStorage.DefaultInstance;

        //uploadting image to firestore bucket
        var nftImageReferance = storage.GetReference($"/NftsImageCollection/{Guid.NewGuid()}.png");
        var bytes = nftImage.EncodeToPNG();
        var nftImageMetadata = new MetadataChange();
        nftImageMetadata.ContentType = "image/png";
        var uploadTask = nftImageReferance.PutBytesAsync(bytes, nftImageMetadata);
        yield return new WaitUntil(() => uploadTask.IsCompleted);
        if (uploadTask.Exception != null)
        {
            Debug.LogError($"Failed to upload because{uploadTask.Exception}");
            yield break;
        }

        var getUriTask = nftImageReferance.GetDownloadUrlAsync();
        yield return new WaitUntil(() => getUriTask.IsCompleted);
        if (getUriTask.Exception != null)
        {
            Debug.LogError($"Failed to get url because{uploadTask.Exception}");
            yield break;
        }
        Debug.Log($"Download from {getUriTask.Result}");
        Debug.LogError(nftImageReferance.Name);

        data.image = getUriTask.Result.ToString();
        //uploading meta data in as json in firestore bucket
        var json = JsonConvert.SerializeObject(data);
        var nftMetaDataReferance = storage.GetReference($"/NftsMetaDataCollection/{Guid.NewGuid()}.json");
        var nftMetabytes = System.Text.Encoding.UTF8.GetBytes(json);
        var myNftMetadata = new MetadataChange();
        myNftMetadata.ContentType = "application/json";
        var uploadNftMetaDataTask = nftMetaDataReferance.PutBytesAsync(nftMetabytes, myNftMetadata);
        yield return new WaitUntil(() => uploadNftMetaDataTask.IsCompleted);
        if (uploadNftMetaDataTask.Exception != null)
        {
            Debug.LogError($"Failed to upload because{uploadNftMetaDataTask.Exception}");
            yield break;
        }

        var getNftMetaDataUriTask = nftMetaDataReferance.GetDownloadUrlAsync();
        yield return new WaitUntil(() => getNftMetaDataUriTask.IsCompleted);
        if (getNftMetaDataUriTask.Exception != null)
        {
            Debug.LogError($"Failed to get url because{getNftMetaDataUriTask.Exception}");
            yield break;
        }
        Debug.Log($"Download from {getNftMetaDataUriTask.Result}");
        Debug.LogError(nftMetaDataReferance.Name);
        nftMinter.Mint(getNftMetaDataUriTask.Result.ToString());
    }
}
