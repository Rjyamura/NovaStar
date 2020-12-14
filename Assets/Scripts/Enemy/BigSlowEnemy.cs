using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlowEnemy : EnemyAbstractClass
{
    [SerializeField]
    private GameObject[] _weaponPrefabs;

    [SerializeField]
    private bool _lasersOn;

    [SerializeField]
    private float _laserDelay;

    [SerializeField]
    private float _laserFire;

    [SerializeField]
    private bool _fireBreak;



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _hp = 10f;
        Instantiate(_powerUpPrefab, transform.position, Quaternion.identity);
    }    

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        WeaponFire();
    }
   

    protected override void WeaponFire()
    {
        if (Time.time > _fireCD && _lasersOn && !_fireBreak)
        {
            _fireCD = Time.time + _fireRate;
            _lasersOn = false;
            WeaponsDelay();
        }

       if (Time.time > _fireCD  && !_lasersOn && !_fireBreak)
        {
            _fireCD = Time.time + _fireRate;
            _lasersOn = true;
            WeaponsDelay();
        }
      
    }

    private void WeaponsDelay()
    {
        if (_lasersOn)
        {
            _lasersOn = false;
            StartCoroutine(FireSecondWeapon());
        }
        else
        {
            _lasersOn = true;
            StartCoroutine(FireFirstWeapon());
        }
    }

    private IEnumerator FireSecondWeapon()
    {

        yield return new WaitForSeconds(10f);
        Instantiate(_weaponPrefabs[1], _weaponPos.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        _lasersOn = true;
        _fireBreak = true;
        StartCoroutine(FireBreak());
    }

    private IEnumerator FireFirstWeapon()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(_weaponPrefabs[0], _weaponPos.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        _lasersOn = false;
        _fireBreak = true;
        StartCoroutine(FireBreak());
    }

    private IEnumerator FireBreak()
    {
        yield return new WaitForSeconds(5f);
        _fireBreak = false;
    }
}
