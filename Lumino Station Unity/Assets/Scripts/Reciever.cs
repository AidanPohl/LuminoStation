/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Laser Beam Detection for Laser Reciever
 *
 * 
 * */using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    public bool Islit;
    public WinCheck check;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")//Laser is hitting reciever AKA level is WIN!!!
        {
            Islit = true;
            check.fulfilled = true;
        }//end if (other.gameObject.tag == "Laser")
    }//end OnTriggerEnter

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Laser")//Laser is no longer hitting reciever AKA level is no longer WIN
        {
            Islit = false;
            check.fulfilled = false;
        }
    }
}
