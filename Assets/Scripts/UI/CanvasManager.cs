using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    private Text _walletText = default;
    private Text _capaText = default;

    //É{É^ÉìîÑãpóp
    static public void Drop()
    {
        GAME_MAIN.money += GAME_MAIN.capa;
        GAME_MAIN.capa = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        _capaText = transform.Find("CapacityText").GetComponent<Text>();
        _walletText = transform.Find("WalletText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _walletText.text = $"Åè{NUMBERFORMAT.FormatNumberWithUnit(GAME_MAIN.money)}";
        _capaText.text = $"{NUMBERFORMAT.FormatNumberWithUnit(GAME_MAIN.capa)}W";
    }
}
