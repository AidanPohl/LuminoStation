/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
 * 
 * Description: Laser Beam Detection
 *
 * 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{   
    /*** VARIABLES ***/
    [Header("Set In Inspector")]
    public Material unlitMat;
    public Material litMat;
    public Material shadowMat;
    public bool interactable; //player can manip while lit
    [Header("Set Dynamically")]
    public bool laserLit = false;
    public bool wasLit = false;
    private MeshRenderer mesh;
    
    // Start is called before the first frame update
    void Start()
    { 
        mesh = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Laser"){
            laserLit = true;
            wasLit = true;
            UpdateMat();
        }
    }

    void OnCollisionExit(Collision other){
        if (other.gameObject.tag == "Laser"){
            laserLit = false;
            UpdateMat();
        }
    }

    private void UpdateMat(){
        if (laserLit){
            mesh.material = litMat;
        } else if (wasLit){
            mesh.material = shadowMat;
        } else {
            mesh.material = unlitMat;
        }
    }
}
