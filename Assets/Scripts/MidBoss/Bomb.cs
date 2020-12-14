using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _speed = 10.0f;
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _hitVolume = 1.0f;

    [SerializeField]
    private float _fireVolume = 1.0f;

    [SerializeField] protected GameObject _explosionAnim;

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private AudioClip _hitSfxsource;

    private void Start()
    {
        if (_sfxSource != null)
        {
            AudioManager.Instance.PlayEffect(_sfxSource, _fireVolume);
        }

        transform.Rotate(0f, 270f, 0);
    }
    private void FixedUpdate()
    {
        Movement();
        if (transform.position.x > 40 || transform.position.x < -40)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
    public void Movement()
    {
        _rb.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthAndDamage>().PlayerDamage();

            if (_explosionAnim != null)
            {

                GameObject explosion = Instantiate(_explosionAnim, transform.position, Quaternion.identity);
                explosion.gameObject.GetComponent<ExplosionAnim>()._sfxSource = _hitSfxsource;
                explosion.gameObject.GetComponent<ExplosionAnim>()._volume = _hitVolume;

            }

            Destroy(gameObject);
        }
    }
}
