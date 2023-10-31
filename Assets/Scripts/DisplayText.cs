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
    public int SniperAmmo = 6;
    public int TotalSniperAmmo = 56;
    public int ShotgunAmmo = 4;
    public int TotalShotgunAmmo = 16;
    public int MagCount;
    public int TotalAmmoCount;
    public Player player;


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
        if (player.GetWeaponType().Equals("Sniper"))
        {
            TotalAmmoCount += 6 ;
        }
        if (player.GetWeaponType().Equals("Shotgun"))
        {
            TotalAmmoCount += 12;
        }

    }

    public void SwitchSniper()
    {
        ShotgunAmmo = MagCount;
        TotalShotgunAmmo = TotalAmmoCount;
        MagCount = SniperAmmo;
        TotalAmmoCount = TotalSniperAmmo;
    }
    public void SwitchShotgun() 
    {
        SniperAmmo = MagCount;
        TotalSniperAmmo = TotalAmmoCount;
        MagCount = ShotgunAmmo;
        TotalAmmoCount = TotalShotgunAmmo;
    }
}
