 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ContractCredentials
{
    [SerializeField]
    private string contractName;
    [SerializeField]
    private string contractAddress;
    [SerializeField]
    private string contractABI;
    public string ContractName()
    {
        return contractName;
    }
    public string ContractAddress()
    {
        return contractAddress;
    }
    public string ContractABI()
    {
        return contractABI;
    }
}

[CreateAssetMenu(fileName ="NewContract", menuName ="ContractData")]
public class GenftContractScriptable : ScriptableObject
{
    public ContractCredentials contractCredentials;
}
