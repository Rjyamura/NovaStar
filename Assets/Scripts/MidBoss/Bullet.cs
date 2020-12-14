using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _dir;
    [SerializeField]
    private float _speed = 10.0f;

    [SerializeField]
    private float _fireVolume = 1.0f;

    [SerializeField] protected GameObject _explosionAnim;

    [SerializeField]
    private float _hitVolume = 1.0f;

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private AudioClip _hitSfxsource;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GetComponentInChildren<SpriteRenderer>().flipX = true;

        if (_sfxSource != null)
        {
            AudioManager.Instance.PlayEffect(_sfxSource, _fireVolume);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);

        if(transform.position.x > 40 || transform.position.x < -40)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        _dir = dir;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
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
