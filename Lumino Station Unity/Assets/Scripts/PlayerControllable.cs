/**
 * Created By: Aidan Pohl
 * Created: 02/20/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 02/21/2022
 * 
 * Description: Player Controller script
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllable : MonoBehaviour
{   public bool hoverOver;
    private GameObject gameController;
    public bool interactable;
    private GameObject indicator;
    public GameObject indicatorPrefab;
    public GameObject movingObject  ;
    private float rotate = 0;
    private float shift = 0;
    public bool rotatable, shiftable;
    public float rotScale = 50f;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("_GameManager");
        indicator = Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        indicator.SetActive(false);
    }

    void OnMouseDown(){
        //if (hoverOver && interactable)
        //gameController.GetComponent<PlayerControls>().SelectedObject(gameObject);
    }

    void OnMouseEnter (){
        hoverOver = true;
    }

    void OnMouseExit(){
        hoverOver = false;
    }

    public void SetHalo(bool halo){
        if(halo){
            indicator.SetActive(true);
        } else{
            indicator.SetActive(false);
        }
    }

    void Update(){
        if (!interactable && gameController.GetComponent<PlayerControls>().selectedObject == gameObject){
            indicator.SetActive(false);
            gameController.GetComponent<PlayerControls>().SelectedObject(null);
        }
    }

    public void SetMovement (float horz = 0f, float vert = 0f){
        rotate = vert;
        shift  = horz;
    }

    void FixedUpdate(){
        gameObject.transform.RotateAround(transform.position, Vector3.forward, rotate*rotScale*Time.deltaTime);
    }
}
