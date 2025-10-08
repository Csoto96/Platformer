using TMPro;
using UnityEngine;

public class CoinHud : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    private int GoldAmount = 0;
    void Start()
    {
        GoldText.text = "0";
    }

    // Update is called once per frame
    public void IncreaseCoin(string type)
    {
        if (type == "Gold")
        {
            GoldAmount += 1;
            GoldText.text = GoldAmount.ToString();
        }
    }
}
