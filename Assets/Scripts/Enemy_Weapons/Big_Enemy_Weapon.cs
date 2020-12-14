using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15;

    public PlayerHealthAndDamage player;

    public GameObject playerObj;

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private AudioClip _hitSfxsource;

    [SerializeField] protected GameObject _explosionAnim;

    [SerializeField]
    private float _fireVolume = 1.0f;

    [SerializeField]
    private float _hitVolume = 1.0f;

    private void Start()
    {
        if (_sfxSource != null)
        {
            AudioManager.Instance.PlayEffect(_sfxSource, _fireVolume);
        }

        playerObj = GameObject.Find("Player");

        if (playerObj == null)
        {
            Debug.Log("Player is NULL");
        }
        else
        {
            player = playerObj.GetComponent<PlayerHealthAndDamage>();
        }
    }


    // Start is called before the first frame update
    void Update()
    {
        WeaponMovement();
    }

    public void WeaponMovement()
    {

        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -37)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(player != null)
            {
                player.PlayerDamage();
            }
            

            if (_explosionAnim != null)
            {

                GameObject explosion = Instantiate(_explosionAnim, transform.position, Quaternion.identity);
                explosion.gameObject.GetComponent<ExplosionAnim>()._sfxSource = _hitSfxsource;
                explosion.gameObject.GetComponent<ExplosionAnim>()._volume = _hitVolume;

            }
            Destroy(this.gameObject);
        }
    }
}
