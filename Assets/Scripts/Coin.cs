using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinData coinData;
    public CoinHud collector;
    // added by Connor
    [SerializeField] SMScript sound_manager;
    private void Awake()
    {
        GameObject sm_obj = GameObject.Find("SoundManager");
        if (sm_obj)
            sound_manager = sm_obj.GetComponent<SMScript>();
    }
    // -----------------

    public void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            // Added by Connor
            sound_manager.CollectableSound();
            // ---------------

            inventory.AddCoin(coinData.value);
            Destroy(gameObject);
        }
        if (coinData.coinName.Contains("Gold"))
        {
            collector.IncreaseCoin("Gold");
        }
    }
}
