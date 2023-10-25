using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public static DisplayText instance;
    public TMPro.TMP_Text textEl;
    public string Textdis;
    public int CoinCount;
    public Text ammoText;
    public int MagCount = 6;
    public int TotalAmmoCount = 54;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Textdis = "Coins:" + CoinCount.ToString();
        textEl.text = Textdis;
        ammoText.text = "Ammo " + MagCount.ToString() + "/" + TotalAmmoCount.ToString();
    }

    public void AddCoin()
    {
        CoinCount++;
    }

    public void Reload()
    {
        if (TotalAmmoCount > 0)
        { 
        int tempRemove = 6;
        tempRemove -= MagCount;
        MagCount = 6;
        TotalAmmoCount -= tempRemove;
        }
    }

    public void RemoveBullet()
    {
        MagCount--;
    }
    
    public int GetBullet()
    {
        return MagCount;
    }

    public void AddTotalAmmo()
    {
        TotalAmmoCount += 28;
    }
}
