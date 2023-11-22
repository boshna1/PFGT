using JetBrains.Annotations;
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
    public int ARAmmo = 28;
    public int TotalARAmmo = 168;
    public int BurstAmmo = 42;
    public int TotalBurstAmmo = 168;
    public int MagCount;
    public int TotalAmmoCount;
    public int tempMagCount;
    public string currentWeap;
    public string prevWeap;
    public Player player;
    public GameObject AmmoSlider;
    public enum WeaponRarity
    {
        Common,
        Rare,
        Epic,
        Legendary

    }

    WeaponRarity BurstRare;
    WeaponRarity ArRare;
    int RareAdd;
    int RareAdd2;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CheckRare();
    }

    // Update is called once per frame
    void Update()
    {
        Textdis = "Coins:" + CoinCount.ToString();
        textEl.text = Textdis;
        ammoText.text = "Ammo " + MagCount.ToString() + "/" + TotalAmmoCount.ToString();
        AmmoSlider.GetComponent<Slider>().value = ((float)MagCount / (float)tempMagCount);     
        Debug.Log(RareAdd);
        Debug.Log(RareAdd2);
    }

    public void AddCoin()
    {
        CoinCount++;
    }

    public void Reload()
    {
        if (TotalAmmoCount > 0 && !currentWeap.Equals("AR"))
        { 
        int tempRemove = 6;
        tempRemove -= MagCount;
        MagCount = 6;
        TotalAmmoCount -= tempRemove;
        }
        if (TotalAmmoCount > 0 && currentWeap.Equals("AR"))
        {
            int tempRemove = 28 + RareAdd2;
            tempRemove -= MagCount;
            MagCount = 28 + RareAdd2;
            TotalAmmoCount -= tempRemove;
        }
        if (TotalAmmoCount > 0 && currentWeap.Equals("Burst"))
        {
            int tempRemove = 42 + RareAdd;
            tempRemove -= MagCount;
            MagCount = 42 + RareAdd;
            TotalAmmoCount -= tempRemove;
        }
    }

    public void RemoveBullet()
    {
        MagCount--;
        if (currentWeap == "Burst")
        {
            Invoke("MagDown",0.1f);
            Invoke("MagDown", 0.2f);
        }
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
        if (player.GetWeaponType().Equals("AR"))
        {
            TotalAmmoCount += 56;
        }
        if (player.GetWeaponType().Equals("Burst"))
        {
            TotalAmmoCount += 56;
        }

    }

    public void SwitchSniper()
    {
        prevWeap = currentWeap;
        if (prevWeap == "Shotgun")
        {
            ShotgunAmmo = MagCount;
            TotalShotgunAmmo = TotalAmmoCount;
        }
        if (prevWeap == "AR")
        {
            ARAmmo = MagCount;
            TotalARAmmo = TotalAmmoCount;
        }
        if (prevWeap == "Burst")
        {
            BurstAmmo = MagCount;
            TotalBurstAmmo = TotalAmmoCount;
        }
        MagCount = SniperAmmo;
        tempMagCount = 6;
        TotalAmmoCount = TotalSniperAmmo;
        currentWeap = "Sniper";
    }
    public void SwitchShotgun() 
    {
        prevWeap = currentWeap;
        if (prevWeap == "Sniper")
        {
            SniperAmmo = MagCount;
            TotalSniperAmmo = TotalAmmoCount;
        }
        if (prevWeap == "AR")
        {
            ARAmmo = MagCount;
            TotalARAmmo = TotalAmmoCount;
        }
        if (prevWeap == "Burst")
        {
            BurstAmmo = MagCount;
            TotalBurstAmmo = TotalAmmoCount;
        }
        MagCount = ShotgunAmmo;
        tempMagCount = 4;
        TotalAmmoCount = TotalShotgunAmmo;
        currentWeap = "Shotgun";
    }
    public void SwitchAR()
    {
        prevWeap = currentWeap;
        if (prevWeap == "Sniper")
        {
            SniperAmmo = MagCount;
            TotalSniperAmmo = TotalAmmoCount;
        }
        if (prevWeap == "Shotgun")
        {
            ShotgunAmmo = MagCount;
            TotalShotgunAmmo = TotalAmmoCount;
        }
        if (prevWeap == "Burst")
        {
            BurstAmmo = MagCount;
            TotalBurstAmmo = TotalAmmoCount;
        }
        MagCount = ARAmmo;
        tempMagCount = 28 + RareAdd2;
        TotalAmmoCount = TotalARAmmo;
        currentWeap = "AR";
    }
    public void SwitchBurst()
    {
        prevWeap = currentWeap;
        if (prevWeap == "Sniper")
        {
            SniperAmmo = MagCount;
            TotalSniperAmmo = TotalAmmoCount;
        }
        if (prevWeap == "Shotgun")
        {
            ShotgunAmmo = MagCount;
            TotalShotgunAmmo = TotalAmmoCount;
        }
        if (prevWeap == "AR")
        {
            ARAmmo = MagCount;
            TotalARAmmo = TotalAmmoCount;
        }
        MagCount = BurstAmmo;
        tempMagCount = 42 + RareAdd;
        TotalAmmoCount = TotalBurstAmmo;
        currentWeap = "Burst";
    }
    public void MagDown()
    {
        MagCount--;
    }

    public void SetBurstRare(string input)
    {
        if (input == "Common")
        {
            BurstRare = WeaponRarity.Common;
        }
        if (input == "Rare")
        {
            BurstRare = WeaponRarity.Rare;
        }
        if (input == "Epic")
        {
            BurstRare = WeaponRarity.Epic;
        }
        if (input == "Legnedary")
        {
            BurstRare = WeaponRarity.Legendary;
        }
    }
    public void SetArRare(string input)
    {
        if (input == "Common")
        {
            ArRare = WeaponRarity.Common;
        }
        if (input == "Rare")
        {
            ArRare = WeaponRarity.Rare;
        }
        if (input == "Epic")
        {
            ArRare = WeaponRarity.Epic;
        }
        if (input == "Legnedary")
        {
            ArRare = WeaponRarity.Legendary;
        }
    }

    void CheckRare()
    {
        if (BurstRare == WeaponRarity.Common)
        {
            RareAdd = 2;
            BurstAmmo += 2;
        }
        if (BurstRare == WeaponRarity.Rare)
        {
            RareAdd = 4;
            BurstAmmo += 8;
        }
        if (BurstRare == WeaponRarity.Epic)
        {
            RareAdd = 6;
            BurstAmmo += 8;
        }
        if (BurstRare == WeaponRarity.Legendary)
        {
            RareAdd = 8;
            BurstAmmo += 8;
        }
        if (ArRare == WeaponRarity.Common)
        {
            RareAdd2 = 2;
            ARAmmo += 2;
        }
        if (ArRare == WeaponRarity.Rare)
        {
            RareAdd2 = 4;
            ARAmmo += 4;
        }
        if (ArRare == WeaponRarity.Epic)
        {
            RareAdd2 = 6;
            ARAmmo += 6;
        }
        if (ArRare == WeaponRarity.Legendary)
        {
            RareAdd2 = 8;
            ARAmmo += 8;
        }
    }
}
