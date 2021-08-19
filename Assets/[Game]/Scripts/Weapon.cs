using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] float damage = 20f;
    //[SerializeField] GameObject muzzleSprite;
    [SerializeField] ParticleSystem dash;
    //[SerializeField] ParticleSystem fireball;
    [SerializeField] GameObject fireball;
    [SerializeField] float shootForce = 5f;

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
            GameObject projectile = (GameObject)Instantiate(fireball, fpCamera.transform.position, fpCamera.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(fireball.transform.forward* shootForce); 
        }

        //if (Input.GetButton("Fire1"))
        //{
        //    
        //}
        //else if (Input.GetButtonUp("Fire1"))
        //{
        //    fireball.Stop();
        //}
     
    }

    void Shoot()
    {
       
        ProcessRaycast();
        
    }

    public void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing:" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); 
            if (target == null) return; //enemy yerine diger objelere ates edersem.
            target.TakeDamage(damage); // asil oldurecek olan bu.
            

        }
        else
        {
            
        }
    }

    void MuzzleFlash()
    {
        if(true)
        {
          
        }
        
        
    }
    

        
}
