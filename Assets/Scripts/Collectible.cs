using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int CoinCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
            DisplayText.instance.AddCoin();
            Debug.Log("ding");
        }
    }
    
}
