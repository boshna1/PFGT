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
    }

    public void AddCoin()
    {
        CoinCount++;
    }
}
