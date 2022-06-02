using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Genft.WalletEvents;

public class Genft2022BalanceOf : MonoBehaviour
{
    public GenftContractScriptable genftContract;
    public async void CheckTokkenBalance() {
        // set chain: ethereum, moonbeam, polygon etc
        string chain = "ethereum";
        // set network mainnet, testnet
        string network = "rinkeby";
        // smart contract method to call
        string method = "balanceOf";
        // abi in json format
        string abi ="";
        // address of contract
        string contract =genftContract.contractCredentials.ContractAddress();
        // array of arguments for contract
        string[] obj ={""};
        string args = JsonConvert.SerializeObject(obj);
        // connects to user's browser wallet to call a transaction
        string response = await EVM.Call(chain, network, contract, abi, method, args);
        WalletEventManager.OnTokkenBalanceCheck?.Invoke(float.Parse(response));
    }
}
