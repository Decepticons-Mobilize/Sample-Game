using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class Gun : ShooterController
{
    [SerializeField] [Range(0.5f, 1.5f)] private float fireRate = 1.0f;
    [SerializeField] [Range(1.0f, 10f)]  private int fireDamage = 1;
    private float timer;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletSpeed;
    [SerializeField] ParticleSystem muzzleParticle;
    [SerializeField] AudioSource gunSound;
    protected override void Awake()
    {
        base.Awake();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                timer = 0f;
                StartCoroutine(FireGunAnimation());
            }
        }
    }
    private IEnumerator FireGunAnimation() 
    {
        charAnimator.SetBool("Shoot", true);
        yield return new WaitForSeconds(0.5f);
        FireGun();
    }
    private void FireGun() 
        {
        
        muzzleParticle.Play();
        gunSound.Play();

        GameObject ammo = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        ammo.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        // Ray ray = new Ray(bulletSpawn.position, bulletSpawn.forward);
        RaycastHit hit;

        
        }


    }


