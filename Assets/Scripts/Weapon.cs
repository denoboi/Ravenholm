using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera fpCamera;
    [SerializeField] float damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing:" + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); 
            if (target == null) return; //enemy yerine diger objelere ates edersem.
            target.TakeDamage(damage); // asil oldurecek olan bu.

        }
       
        
       
    }
}
