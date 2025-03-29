using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string buy20Coin = "com.aurumworldsgames.helixjump.buy20coins";
    private string buy50Coin = "com.aurumworldsgames.helixjump.buy50coins";
    private string buy100Coin = "com.aurumworldsgames.helixjump.buy100coins";
    private string buy200Coin = "com.aurumworldsgames.helixjump.buy200coins";
    private string removeAds = "com.aurumworldsgames.helixjump.removeads";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == buy20Coin)
        {
            //reward the player
            Debug.Log("You have been rewarded 20 coin");
            GameManager.singleton.coins += 20;
        }

        if (product.definition.id == buy50Coin)
        {
            //reward the player
            Debug.Log("You have been rewarded 50 coin");
            GameManager.singleton.coins += 50;
        }
        if (product.definition.id == buy100Coin)
        {
            //reward the player
            Debug.Log("You have been rewarded 100 coin");
            GameManager.singleton.coins += 100;
        }
        if (product.definition.id == buy200Coin)
        {
            //reward the player
            Debug.Log("You have been rewarded 200 coin");
            GameManager.singleton.coins += 200;
        }
        if(product.definition.id == removeAds)
        {
            //remove ads
            Debug.Log("AdRemoved");
        }
        else
        {
            Debug.Log("not productId");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
}
