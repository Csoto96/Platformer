using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Powerup : MonoBehaviour
{
    [SerializeField] private SMScript sound_manager;
    public PowerupEffect powerupEffect;

    private void Awake()
    {
        if (sound_manager == null)
        {
            GameObject sm_obj = GameObject.Find("SoundManager");
            if (sm_obj != null)
            {
                sound_manager = sm_obj.GetComponent<SMScript>();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
            sound_manager.PowerupSound();
        }
    }
}
