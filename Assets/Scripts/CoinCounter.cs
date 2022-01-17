using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static int coincount;
    Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coincount = 0;
        coinText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coincount.ToString();
    }
}
