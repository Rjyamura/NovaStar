using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private AudioClip _musicSource;

    [SerializeField]
    private float _volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(_musicSource, _volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
