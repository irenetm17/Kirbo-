using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public int coinCount;
    public TextMeshProUGUI coinText;

    private void Update()
    {
        coinText.text = "Estrellas: " + coinCount.ToString();
    }
}
