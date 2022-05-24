using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Genft.WalletEvents;

public class WalletManager : MonoBehaviour
{
    [SerializeField]
    private GenftContractScriptable genftContract;
    public string WalletAddress{get;private set;}
    [SerializeField]
    private Text walletTextAddress;
    private void OnEnable() {
        WalletEventManager.onWalletLoggedIn.Addlistener(SetWalletAddress);   
    }
    private void SetWalletAddress(string address)
    {
        WalletAddress=address;
        walletTextAddress.text=WalletAddress;
    }
    private void OnDisable() {
        WalletEventManager.onWalletLoggedIn.RemoveListener(SetWalletAddress);
    }
}
