using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] float damage = 20f;
    [SerializeField] GameObject muzzleSprite;
    // Start is called before the first frame update
    Run spriteDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            muzzleSprite.SetActive(true);
            if (spriteDelay != null)
                spriteDelay.Abort();
          spriteDelay =  Run.After(0.2f, () =>
            {
                muzzleSprite.SetActive(false);
            });
        }
     
    }

    void Shoot()
    {
        muzzleSprite.SetActive(true);
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
            muzzleSprite.SetActive(true);

        }
        else
        {
            muzzleSprite.SetActive(false);
        }
    }

    void MuzzleFlash()
    {
        if(true)
        {
          
        }
        muzzleSprite.SetActive(true);
        
    }
    

        
}
