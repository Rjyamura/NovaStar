using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float _speed = 60.0f;

    [SerializeField]
    private float _hitVolume = 1.0f;

    [SerializeField]
    private float _fireVolume = 1.0f;

    private bool _isEnemyShot = false;

    [SerializeField] protected GameObject _explosionAnim;

    [SerializeField]
    private float damage;

    [SerializeField]
    private AudioClip _sfxSource;

    [SerializeField]
    private AudioClip _hitSfxsource;

    // Start is called before the first frame update
    void Start()
    {
        if(_sfxSource != null)
        {
            AudioManager.Instance.PlayEffect(_sfxSource, _fireVolume);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnemyShot)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }


    void MoveRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (transform.position.x > 35.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }


    void MoveLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.x < -35.0)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void AssignEnemyShot()
    {
        _isEnemyShot = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && _isEnemyShot != true)
        {
            Debug.Log("Enemy hit detected");
            EnemyAbstractClass enemy = other.GetComponent<EnemyAbstractClass>();

            if (enemy != null)
            {
                enemy.Damage(damage);

                if(_explosionAnim != null)
                {

                    GameObject explosion  = Instantiate(_explosionAnim, transform.position, Quaternion.identity);
                    explosion.gameObject.GetComponent<ExplosionAnim>()._sfxSource = _hitSfxsource;
                    explosion.gameObject.GetComponent<ExplosionAnim>()._volume = _hitVolume;

                }
               
            }
        }
    }

}
