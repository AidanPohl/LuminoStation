/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
 * 
 * Description: Laser Beam propogation
 *
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private LineRenderer beam;
    public float beamStrength = 100f;
    private List<Vector3> points;
    // Start is called before the first frame update
    void Start()
    {   beam = GetComponent<LineRenderer>(); //Line renderer refrence
        beam.enabled = false;               //disables beam until needed
        beam.SetPosition(0,transform.position);
    }


    //Begins firing the beam from the transform of the object.
    public void ShootBeam(float length){
        beam.positionCount=1; //Starts beam as a single point
        beam.SetPosition(0,transform.position);

        ShootBeam(length, 1, transform.position,transform.TransformDirection(Vector3.forward));
        
        beam.enabled = true;//turns on beam
    }//end ShootBeam(float length)

    //adds a point onto the end of the beam recursively until length is maxed out
    public void ShootBeam(float length, int numPoint, Vector3 endPoint ,Vector3 angle){
        RaycastHit hit = new RaycastHit();
        bool collide = Physics.Raycast(endPoint, angle,out hit,length);
        //Checks if the Raycast collides with something
        if(collide){//collides
            endPoint = hit.point;
            length -= hit.distance;
            angle = Vector3.Reflect(angle,hit.normal);
        } else{//Does not collide
            endPoint += angle*length;
            length = 0;
        }
        beam.positionCount++;//Adds a position to the line renderer
        beam.SetPosition(numPoint,endPoint);
        if(length > 0 && hit.transform.gameObject.tag == "Reflective"){
        ShootBeam(length,numPoint+1,endPoint, angle);//Recurses ShootBeam with decreased length at new position and angle
        }//end if(hit.transform.gameObject.tag=="Reflective" && length > 0){
    }//end ShootBeam (float length, int numPoint, Vector3 endPoint ,Vector3 angle)

    // Update is called once per frame
    void Update(){

        ShootBeam(beamStrength);
    }
}
