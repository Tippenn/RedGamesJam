using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [Header("Source")]
    public AudioSource BGM;
    public AudioSource SFX;

    [Header("Clip")]
    [Header("BGM")]
    public AudioClip inGame;
    public AudioClip lobbyAndMainMenu;
    [Header("SFX")]
    public AudioClip click;
    public AudioClip tap;

    public void PlaySFXOneShot(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip audioClip)
    {
        if (BGM.clip == audioClip) return;

        BGM.clip = audioClip;
        BGM.Play();
    }

    
}
