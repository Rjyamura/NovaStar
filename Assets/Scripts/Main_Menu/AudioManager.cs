using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton Pattern
    private static AudioManager _instance;
    public static AudioManager Instance 
    { 
        get
        {
            if (_instance == null)
            {
                Debug.LogError("The AudioManager is NULL.");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    #region Instructions for Use
    //AudioClip(effect/music) will be the sound/music you want to play
    //Volume will set a float value from 0, 1

    //When accessing the singleton from another game object use AudioManager.Instance
    //EXAMPLES:

    //For Sound Effects: ----------------------------------------------
    //AudioManager.Instance.PlayEffect(_YOURSFX, VOLUMEFROM|0-1); 
    //This will play one shots, allowing sound effects to overlap.
    //Looping sound effects will not work with this implementation.  You will need to implement other Audio Sources for these.

    //For Music: ------------------------------------------------------
    //AudioManager.Instance.PlayMusic(_YOURMUSICCLIP, VOLUMEFROM|0-1); 
    //This will set your music clip to loop and play - if there is already a music clip playing, this will overwrite the current track.
    //Only one looping music clip can be played at a time per this source.
    #endregion

    [SerializeField]
    private AudioSource _sfxSource;
    [SerializeField]
    private AudioSource _bgmSource;

    public void PlayEffect(AudioClip effect, float volume)
    {
        _sfxSource.PlayOneShot(effect, volume);
    }

    public void PlayMusic(AudioClip music, float volume) 
    {
        _bgmSource.Stop();
        _bgmSource.clip = music;
        _bgmSource.volume = volume;
        _bgmSource.loop = true;
        _bgmSource.Play();
    }


}
