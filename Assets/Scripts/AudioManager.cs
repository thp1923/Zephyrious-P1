using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip -------------")]
    public AudioClip Background;
    public AudioClip Jump;
    public AudioClip Fall;
    public AudioClip SwordSwing;
    public AudioClip PlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}