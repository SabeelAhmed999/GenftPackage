# GenftPackage
A custom unity package made after working day and night for countless hours,through ChainSafe Gaming SDK which is used to enable crypto wallet connection and web3 functionality in android, webgl and PC builds (tested), also can be used for ios build (not tested).

Functionalities available:
Establish a secure wallet connection.
Mint Nft within the app.
Balance check of a tokken.

Functionalities capable of:
Check the owner of a token or nft.
Transfer token
Transfer ownership of a token
As we have now available the functionality of read as well write to smart contract so as long as your contract contains the proper function you can easily make an interaction/call function within unity.

Standard Behaviour:
It makes a connection to walle after the login call is made, as soon call is made it opens the metamast wallet (app or chrome/firefox extension need to be installed) and ask for user wallet credentials then ask to sign the app then ask to copy the wallet address and go back to app. 
As being a sensible person you have copied the wallet address so it will establish a connection as you return to your app, but if you haven’t copied the address by mistake or want to break the connection don’t worry I have covered for you it will show through error or wait until you go back and copy the address.
After successful wallet connection you are able to mint your Nft or do any other smart contract call, for Nft the process is the same as login. You get a popup in your wallet or web extension asking for confirmation for the mint call. Be aware it may transfer all your crypto coins to me :) don’t worry just give it a look asking for gas fee for the transaction to be made over block chain.


How to integrate:
You just need to import the Genft package into your project to make sure the Unity version is 2020.3.5 or above. Also you will need to import Firebase storage SDK from dotnet 4 directory and may require Json.Net for Unity now you are set to go.
Hold on you need to configure some stuff now to make it functional.
Download import the google services json file from you firebase console project settings
Then just need to add contract credentials in custom contract scriptable available in Genft/Scripts/SmartContractCalls/CustomContract you can ad as many contract as you want but then you have to handle the proper calling as contract credentials used for minting and for all other smart contract calls
Last you need to use prefabs placed in Genft folder to make it work properly.

