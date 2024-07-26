using UnityEngine;

public class AudioNPC : MonoBehaviour
{
    [Header("-------- Audio Source -----------")]
    [SerializeField] AudioSource SFXSource;
    [Header("-------- Audio Clip Speak -------------")]
    public AudioClip[] speak;
    private int index;

    public void PlaySFXNPC(AudioClip[] clip)
    {
        if (index >= 0 && index < clip.Length)
        {
            SFXSource.PlayOneShot(clip[index]);
            index++;
            Debug.Log("Có chạy " + index);
        }
    }
}