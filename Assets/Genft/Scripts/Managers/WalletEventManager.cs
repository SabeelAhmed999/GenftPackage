using System.Collections;
using System.Collections.Generic;
using System;
namespace Genft.WalletEvents
{
public class WalletEventManager
{
    public static readonly Evt<string> OnWalletLoggedIn=new Evt<string>();
    public static readonly Evt OnWalletLogOut= new Evt();
    public static readonly Evt IfWalletLoggedIn=new Evt();
    public static readonly Evt<string> OnSignRejection=new Evt<string>();
    public static readonly Evt<float> OnTokkenBalanceCheck=new Evt<float>();
}
}
