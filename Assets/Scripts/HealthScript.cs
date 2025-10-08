using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private Slider HealthbarAmount;
    [SerializeField] private GameObject Player;
    private Health playerHealth;
    void Start()
    {
        playerHealth = Player.GetComponent<Health>();
        HealthbarAmount.maxValue = playerHealth.maxHealth;
        HealthbarAmount.value = playerHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthbarAmount.value = playerHealth.currentHealth;
    }
}
