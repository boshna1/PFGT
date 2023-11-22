using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rarity : MonoBehaviour
{
    
    public WeaponRarity GunRarity;
    public WeaponRarity GunRarity2;
    public GameObject particle; 
    public DisplayText dt;
    public RotateTransform rt;
    public RotateTransform rt2;
    bool enable;
    public enum WeaponRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
        {
            GunRarity = WeaponRarity.Common;
        }
        if (random == 1)
        {
            GunRarity = WeaponRarity.Rare;
        }
        if (random == 2)
        {
            GunRarity = WeaponRarity.Epic;
        }
        if (random == 3)
        {
            GunRarity = WeaponRarity.Legendary;
        }
        int random2 = Random.Range(0, 4);
        if (random2 == 0)
        {
            GunRarity2 = WeaponRarity.Common;
        }
        if (random2 == 1)
        {
            GunRarity2 = WeaponRarity.Rare;
        }
        if (random2 == 2)
        {
            GunRarity2 = WeaponRarity.Epic;
        }
        if (random2 == 3)
        {
            GunRarity2 = WeaponRarity.Legendary;
        }
        dt.SetArRare(GunRarity.ToString());
        dt.SetBurstRare(GunRarity2.ToString());
        rt.setGunRarity(GunRarity.ToString());
        rt2.setGunRarity(GunRarity2.ToString());
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            enable = true;
        }

        if (enable == true)
        {
            int random = Random.Range(0, 4);
            if (random == 0)
            {
                GunRarity = WeaponRarity.Common;
            }
            if (random == 1)
            {
                GunRarity = WeaponRarity.Rare;
            }
            if (random == 2)
            {
                GunRarity = WeaponRarity.Epic;
            }
            if (random == 3)
            {
                GunRarity = WeaponRarity.Legendary;
            }
            int random2 = Random.Range(0, 4);
            if (random2 == 0)
            {
                GunRarity2 = WeaponRarity.Common;
            }
            if (random2 == 1)
            {
                GunRarity2 = WeaponRarity.Rare;
            }
            if (random2 == 2)
            {
                GunRarity2 = WeaponRarity.Epic;
            }
            if (random2 == 3)
            {
                GunRarity2 = WeaponRarity.Legendary;
            }
            dt.SetArRare(GunRarity.ToString());
            dt.SetBurstRare(GunRarity2.ToString());
            rt.setGunRarity(GunRarity.ToString());
            rt2.setGunRarity(GunRarity2.ToString());
            enable = false;
        }
    }
}
