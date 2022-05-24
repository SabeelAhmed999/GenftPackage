using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewContract", menuName ="ContractData")]
public class GenftContractScriptable : ScriptableObject
{
    public string contractAddress;
    public string contractABI="";
}
