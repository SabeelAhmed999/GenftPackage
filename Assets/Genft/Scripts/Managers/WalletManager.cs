using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Genft.WalletEvents;

public class WalletManager : MonoBehaviour
{
    public static WalletManager Instance;
    [SerializeField]
    public string WalletAddress{get;private set;}
    [SerializeField]
    private Text walletTextAddress;
    [SerializeField]
    private Text errorMessage;
    public float myTokkenBalance;
    private void Awake() {
        if(Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void OnEnable() {
        WalletEventManager.OnWalletLoggedIn.Addlistener(SetWalletAddress);  
        WalletEventManager.OnSignRejection.Addlistener(OnSignRejection); 
        WalletEventManager.OnTokkenBalanceCheck.Addlistener(OnCheckingTokkenBalance);
        WalletEventManager.OnMintTransactionComplete.Addlistener(OnMintingCompleted);
        WalletEventManager.OnMintTransactionFailed.Addlistener(OnFailedToMint);

    }
    private void SetWalletAddress(string address)
    {
        WalletAddress=address;
        walletTextAddress.text=WalletAddress;
    }
    private void OnCheckingTokkenBalance(float balance)
    {
        myTokkenBalance=balance;
        Debug.Log(myTokkenBalance);
    }
    private void OnSignRejection(string msg)
    {
        errorMessage.text=msg;
        Invoke("ClearAlerts",2.5f);
    }
    private void OnMintingCompleted()
    {
        Debug.Log("Nft Minting successful!");
    }
    private void OnFailedToMint()
    {
        Debug.Log("Failed to Mint!");
    }
    private void OnDisable() {
        WalletEventManager.OnWalletLoggedIn.RemoveListener(SetWalletAddress);
        WalletEventManager.OnSignRejection.RemoveListener(OnSignRejection); 
        WalletEventManager.OnTokkenBalanceCheck.RemoveListener(OnCheckingTokkenBalance);
        WalletEventManager.OnMintTransactionComplete.RemoveListener(OnMintingCompleted);
        WalletEventManager.OnMintTransactionFailed.RemoveListener(OnFailedToMint);
    }
    private void ClearAlerts()
    {
        errorMessage.text="";
    }
}
