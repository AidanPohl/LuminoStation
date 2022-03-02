/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 02/20/2022
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
    public bool selectable;
    [Header("Set Dynamically")]
    public bool laserLit = false;
    public bool wasLit = false;
    private MeshRenderer mesh;
    private GameObject currentCollision;
    // Start is called before the first frame update
    void Start()
    { 
        mesh = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        mesh.material = unlitMat;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Laser" && currentCollision == null){
            laserLit = true;
            wasLit = true;
            if(selectable){
            gameObject.GetComponent<PlayerControllable>().interactable = true;
            }
            UpdateMat();
            currentCollision = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Laser" && other.gameObject == currentCollision){
            Debug.Log("Oy!");
            if(selectable){
            gameObject.GetComponent<PlayerControllable>().interactable = false;
            }
            laserLit = false;
            currentCollision = null;
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
