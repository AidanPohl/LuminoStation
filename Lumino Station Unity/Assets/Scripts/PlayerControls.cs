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

public class PlayerControls : MonoBehaviour
{   
    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(selectedObject != null){
            Vector3 mouseScreen = Input.mousePosition;
            mouseScreen.z = -Camera.main.transform.position.z;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            selectedObject.transform.LookAt(mouseWorld);
        }
    }

    public void SelectedObject (GameObject obj){
        if(selectedObject != null && selectedObject != obj){
            selectedObject.GetComponent<PlayerControllable>().SetHalo(false);
        }
        if(obj!= null &&selectedObject != obj ){
            selectedObject = obj;
            selectedObject.GetComponent<PlayerControllable>().SetHalo(true);
            }
        else if(obj==null && selectedObject != null){
            selectedObject.GetComponent<PlayerControllable>().SetHalo(false);
            selectedObject = null;
        }
    }
    

}
