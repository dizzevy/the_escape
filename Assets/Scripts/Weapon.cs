using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float fireRate = 1f;
    public float range;
    public float force;
    public GameObject hitEffect;
    public ParticleSystem shotEffect;
    public Transform spawnerSE;
    public AudioClip shotSound;
    public AudioSource _audioSource;

    public Camera _cam;

    private float nextFire = 0f;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        _audioSource.PlayOneShot(shotSound);
        //Instantiate(shotEffect, spawnerSE.position, spawnerSE.rotation);
        shotEffect.Play();

        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            Debug.Log("попал");

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
