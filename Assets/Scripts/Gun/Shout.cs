using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shout : MonoBehaviour
{
    AudioSource audio;
    public AudioClip bloodZombie;
    public AudioClip reload;
    public AudioClip bullet;

    
    
    public float coolDown;
    float lastFireTime;
    public int defaultEmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit!")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    public GameObject magObject;
    public ParticleSystem muzzleParticle;

    public int minAngle;
    public int maxAngle;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
        currentAmmo = defaultEmmo - magSize;
        currentMagAmmo = magSize;
        

    }
    

    public void Reload()
    {
        if (currentAmmo == 0 || currentMagAmmo == magSize)
        {
            
            return;
        }
        if (currentAmmo < magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo = 0;
            

        }
        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
            

        }
        GameObject newMagObject = Instantiate(magObject);
        audio.clip = reload;
        audio.Play();
        newMagObject.transform.position = magObject.transform.position;
        newMagObject.AddComponent<Rigidbody>();
    }

    private bool CanFire()
    {
        if (currentMagAmmo > 0 && lastFireTime + coolDown < Time.time)
        {
            lastFireTime = Time.time + coolDown;
            return true;
        }
        return false;
    }

    public void Fire()
    {
        if (CanFire())
        {
            muzzleParticle.Play(true);
            // Buraya mermi sesi koy!
            audio.clip = bullet;
            audio.Play();
            currentMagAmmo -= 1;
            MagAmmo.text = "= " + currentMagAmmo;
            AllAmmo.text = "= " + currentAmmo;

            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "Zombie")
                {
                    hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                    // zombie kan sesi
                    audio.clip = bloodZombie;
                    audio.Play();
                    
                    StartCoroutine(GenerateBloodEffect(hit));
                }
                else
                {
                    
                    StartCoroutine(GenerateHitEffect(hit));
                }
            }
            transform.localEulerAngles = new Vector3((UnityEngine.Random.Range(minAngle, maxAngle)), (UnityEngine.Random.Range(minAngle, maxAngle)), (UnityEngine.Random.Range(minAngle, maxAngle)));
        }
        

    }
    
    

    IEnumerator GenerateHitEffect(RaycastHit hit)
    {
        // Mermi izi oluştur.
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward * -1, hit.normal);
        yield return new WaitForSeconds(5);
        Destroy(hitObject);
        
    }
    IEnumerator GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        yield return new WaitForSeconds(5);
        Destroy(bloodObject);


    }
   


}
