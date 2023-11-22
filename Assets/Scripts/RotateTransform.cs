using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RotateTransform : MonoBehaviour
{
    public GameObject obj;
    public string GunRarity;
    public GameObject particle;
    GameObject tempPart;
    // Start is called before the first frame update
    void Start()
    {
        tempPart = Instantiate(particle, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        obj.transform.Rotate(0f,1f,0f);
        if (GunRarity == "Common")
        {     
            tempPart.GetComponent<ParticleSystem>().startColor = Color.gray;
        }
        if (GunRarity == "Rare")
        {
            tempPart.GetComponent<ParticleSystem>().startColor = Color.blue;
        }
        if (GunRarity == "Epic")
        {
            tempPart.GetComponent<ParticleSystem>().startColor = Color.magenta;
        }
        if (GunRarity == "Legendary")
        {
            tempPart.GetComponent<ParticleSystem>().startColor = Color.yellow;
        }
    }

    public void setGunRarity(string input)
    {
        GunRarity = input;
    }

}
