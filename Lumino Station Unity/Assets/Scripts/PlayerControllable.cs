/**
 * Created By: Aidan Pohl
 * Created: 02/20/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
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
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
        indicator = Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        indicator.SetActive(false);
    }

    void OnMouseDown(){
        if (hoverOver && interactable)
        gameController.GetComponent<PlayerControls>().SelectedObject(gameObject);
    }

    void OnMouseEnter (){
        hoverOver = true;
        Debug.Log("Mouse entered");
    }

    void OnMouseExit(){
        hoverOver = false;
        Debug.Log("Mouse left");
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
}
