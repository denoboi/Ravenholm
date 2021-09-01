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

    public Vector3 aimDownSight;
    public Vector3 hipFire;
    private Vector3 smoothADS;
     
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

            dash.Play();
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

        if (Input.GetMouseButton(1))
        //0, 0.17,0.235
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSight, aimspeed * Time.deltaTime); ;
             
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = hipFire;
        }

    }

    void Shoot()
    {
        
        ProcessRaycast();
        
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
