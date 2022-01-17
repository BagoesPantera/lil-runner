using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    private bool bol = true;
    private void Start() {
        if (bol)
        {
            gameObject.SetActive(true);
            Invoke("SetFalse",3.0f);
        }
    }
    void SetFalse()
    {

        gameObject.SetActive(false);

    }
}
