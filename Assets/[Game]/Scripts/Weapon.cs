using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] Camera muzzleCam;
    [SerializeField] float damage = 20f;
    //[SerializeField] GameObject muzzleSprite;
    [SerializeField] ParticleSystem dash;
    //[SerializeField] ParticleSystem fireball;
    [SerializeField] GameObject fireball;
    [SerializeField] float shootForce = 5f;

    [SerializeField] public Vector3 smoothAds;
    
    [SerializeField] Ammo ammoSlot;
    bool ammoAvailable = true;
    bool isAiming = false;
    public Vector3 aimDownSight;
    public Vector3 hipFire;
    
     
    [SerializeField]
    float aimspeed = 5f;
    

    // Start is called before the first frame update
    //Run spriteDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            //muzzleSprite.SetActive(true);
            //if (spriteDelay != null)
            //spriteDelay.Abort();
            //spriteDelay =  Run.After(0.2f, () =>
            //{
            // muzzleSprite.SetActive(false);
            // });

            
            //fireball.Play();
            GameObject projectile = (GameObject)Instantiate(fireball, transform.position, transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(fireball.transform.forward * shootForce); 
            
        }

        //if (Input.GetButton("Fire1"))
        //{
        //    
        //}
        //else if (Input.GetButtonUp("Fire1"))
        //{
        //    fireball.Stop();
        //}

        if(Input.GetMouseButtonDown(1))
        {


            smoothAds = transform.localPosition;

            isAiming = true;
        }    
        if (Input.GetMouseButton(1))
        //0, 0.17,0.235
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime);
            
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            
        }
        if(isAiming == false && transform.localPosition != hipFire)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, hipFire, 7f * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (ammoAvailable == true)
        {
            ProcessRaycast();
            dash.Play();
            ammoSlot.ReduceAmmo();
        }
        if (ammoSlot.GetCurrentAmmo() <= 0 )
        {
            ammoAvailable = false;
        }

    }

    public void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzleCam.transform.position, muzzleCam.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing:" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; //enemy yerine diger objelere ates edersem.
            target.TakeDamage(damage); // asil oldurecek olan bu.



        }
        //if (Physics.Raycast(transform.localPosition, fpCamera.transform.forward, out hit, range))//aim down sight yapildiginda raycast
        //{
        //    Debug.Log("I hit this thing:" + hit.transform.name);
        //    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        //    if (target == null) return; //enemy yerine diger objelere ates edersem.
        //    target.TakeDamage(damage); // asil oldurecek olan bu.
        //}
    }

    void MuzzleFlash()
    {
        if(true)
        {
          
        }
        
        
    }
    

        
}
