using System.Collections;
using System.Collections.Generic;
using System;
namespace Genft.WalletEvents
{
public class WalletEventManager
{
    public static readonly Evt<string> onWalletLoggedIn=new Evt<string>();
    public static readonly Evt onWalletLogOut= new Evt();

}
}
