using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    public int ammoAmount = 10;

    public int GetCurrentAmmo()
        {
            return ammoAmount;
        }
   
    public void ReduceAmmo()
    {
        ammoAmount--;
    }
}
