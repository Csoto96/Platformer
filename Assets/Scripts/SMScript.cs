using UnityEngine;

public class SMScript : MonoBehaviour
{
    [SerializeField] private AudioClip player_jump_clip;
    [SerializeField] private AudioClip enemy_defeat_clip;
    [SerializeField] private AudioClip collectable_clip;
    [SerializeField] private AudioClip powerup_clip;
    [SerializeField] private AudioClip background_clip;
    [SerializeField] private float background_volume;

    private void Start()
    {
        BackgroundMusic();
    }
    public void JumpSound()
    {
        if (player_jump_clip == null)
        {
            return;
        }
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = player_jump_clip;
        sound.Play();
    }
    public void DefeatSound()
    {
        if (enemy_defeat_clip == null)
        {
            return;
        }
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = enemy_defeat_clip;
        sound.Play();
    }
    public void CollectableSound()
    {
        if (collectable_clip == null)
        {
            return;
        }
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = collectable_clip;
        sound.Play();
    }

    public void PowerupSound()
    {
        if (powerup_clip == null)
        {
            return;
        }
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = powerup_clip;
        sound.Play();
    }

    public void BackgroundMusic()
    {
        if (background_clip == null)
        {
            return;
        }
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = background_clip;
        sound.loop = true;
        sound.volume = background_volume >= 0 ? background_volume : 1f;
        sound.Play();
    }
}
