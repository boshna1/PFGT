using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Player player;
    public int CoinCount = 0;
    public GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && obj.tag == "Coin")
        {
            Destroy(gameObject);
            DisplayText.instance.AddCoin();
            Debug.Log("ding");
        }
        if (other.transform.tag == "Player" && obj.tag == "AmmoBox")
        {
            Destroy(gameObject);
            DisplayText.instance.AddTotalAmmo();
            Debug.Log("ding");
        }
        if (other.transform.tag == "Player" && obj.tag == "AR")
        {
            Destroy(gameObject);
            player.enableAR();
        }
        if (other.transform.tag == "Player" && obj.tag == "Burst")
        {
            Destroy(gameObject);
            player.enableBurst();
        }
    }
    
}
