using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float damage = 21f;
    public float fireRate = 1f;
    public float fireRange = 15f;
    public Transform bulletSpawn;
    public GameObject weaponFlash;
    public AudioSource shotSFX;

    public Camera _camera;
    private float _nextFire = 0f;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        shotSFX.Play();

        Vector3 rotation = bulletSpawn.rotation.eulerAngles;
        rotation.y += 180;
        Quaternion newRotation = Quaternion.Euler(rotation);

        GameObject newObject = Instantiate(weaponFlash, bulletSpawn.position, newRotation);
        Destroy(newObject, .5f);

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, fireRange))
        {   
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                StartCoroutine(enemy.TakeDamage(damage));
            }
        }
    }
}
