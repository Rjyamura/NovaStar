using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private float _volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayEffect(_sfxSource, _volume);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
