using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFireSound : MonoBehaviour
{ 
    [SerializeField]
    public AudioClip _sfxSource;

    [SerializeField]
    public float _volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playSound()
    {

        GetComponent<AudioSource>().clip = _sfxSource;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        yield return null;
    }
}
