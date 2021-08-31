

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public float minFOV = 45;
    [SerializeField]
    private float t = 0.1f;
    

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, minFOV, t);
            
        }
        if(Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = 60;
        }
    }
}
