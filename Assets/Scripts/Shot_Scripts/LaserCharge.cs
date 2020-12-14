using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCharge : MonoBehaviour
{

    private float startTime;

    private bool _laserCharging;

    private bool laserPrimed = false;

    public bool _canShoot;

    private float totalCharge;

    public GameObject _playerObj;

    [SerializeField]
    private PlayerWeaponsFire _playerWepCtrl;

    [SerializeField]
    private AudioClip _chargeStartSoundClip;

    [SerializeField]
    private AudioClip _chargeLoopSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        _playerWepCtrl = _playerObj.GetComponent<PlayerWeaponsFire>();
        startTime = Time.time;
        _laserCharging = true;

        StartCoroutine(playChargeSound());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && _laserCharging)
        {
            totalCharge = Time.time - startTime;

            if (totalCharge >= 3.0f)
            {
                totalCharge = 3.0f;
            }

            if (totalCharge > 0.75f)
            {
                laserPrimed = true;
            }

            if (laserPrimed == true)
            {
                Debug.Log("Key Release Time: " + totalCharge);
                _laserCharging = false;
                laserPrimed = false;
                _playerWepCtrl.FireLaser(totalCharge);      
            }
            else
            {
                Debug.Log("Key Release Time: " + totalCharge);
                Debug.Log("Not enough key charge, Laser cancelled");
                _laserCharging = false;
                _playerWepCtrl.ChargeCancel();
                Destroy(gameObject);
            }
        }
    }


    IEnumerator playChargeSound()
    {
 
        GetComponent<AudioSource>().clip = _chargeLoopSoundClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        yield return null;
    }
}
