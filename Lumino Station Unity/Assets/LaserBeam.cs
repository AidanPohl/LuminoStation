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
    /***Variables***/
    [Header("Set In Inspector")]
    public float beamStrength = 100f; //Total length of beam
    public Vector3 localOffset = (Vector3.zero); //0 by default
    public Vector3 localAngle = (Vector3.zero);  //0 by default
    public Material beamMaterial;
    public float beamWidth =.1f;
    public GameObject lVGOPrefab;
    [Header("Set Dynamically")]
    public GameObject beamGO;
    public LineRenderer beam;      //the visual component of the beam
    public List<float> rLengths;   //remaining lengths after each vertex
    public List<Ray> rays;
    public List<RaycastHit> hits;  //hit of each raycast
    public List<GameObject> vertexes;
    private 


    //creates a new Beam gameobject with line renderer
    public void MakeBeam(){
        //creates a empty game object for the laser beam
        beamGO = new GameObject("Laser");
        beamGO.tag = "Laser";
        beamGO.transform.SetParent(this.transform);
        beamGO.transform.localPosition = localOffset;
        beamGO.transform.localRotation = Quaternion.Euler(localAngle);
        
        //creates the linerenderer for the visible laser beam
        beam = beamGO.AddComponent<LineRenderer>() as LineRenderer;
        beam.material = beamMaterial;
        beam.startWidth = beamWidth;

        //creates lists for the beam creation and propogation
        rLengths = new List<float>();
        rLengths.Add(beamStrength); //first collision at position 1
        rays = new List<Ray>();
        rays.Add(new Ray(localOffset,transform.TransformDirection(Vector3.forward)+localAngle)); //first collision at position 1
        hits = new List<RaycastHit>(); //first collision at position 0
        vertexes = new List<GameObject>();

        ShootBeam();
    }


    //Begins firing the beam from the transform of beamGO.
    public void ShootBeam(){
        beam.positionCount=1;
        rLengths[0] = beamStrength;
        Ray firstRay = rays[0];
        firstRay.direction =transform.TransformDirection(Vector3.forward)+localAngle;
        rays[0] = firstRay;
        beam.SetPosition(0,beamGO.transform.position);

        ShootBeam(1);
    }//end ShootBeam(float length)

    public void ShootBeam(int startPos){
        beam.positionCount=startPos; //Starts beam at position startPos
        rLengths = new List<float>(rLengths.GetRange(0,startPos));
        rays = new List<Ray>(rays.GetRange(0,startPos));
        for (int i = startPos-1; i<vertexes.Count;i++){
            Destroy(vertexes[i]);
        }
        vertexes = new List<GameObject>(vertexes.GetRange(0,startPos-1));
        hits = new List<RaycastHit>(hits.GetRange(0,startPos-1));

        BeamFire(startPos);
        beam.enabled = true;
    }//end ShootBeam(int startPos)


    //adds a point onto the end of the beam recursively until length is maxed out
    public void BeamFire(int numPoint){
        Ray currRay = rays[numPoint-1];
        Ray nextRay = new Ray();
        float length = rLengths[numPoint-1];
        RaycastHit hit = new RaycastHit();
        
        //Checks if the Raycast collides with something
        LayerMask layerMask = -1;
        bool collide = Physics.Raycast(currRay.origin, currRay.direction,out hit,length, layerMask,QueryTriggerInteraction.Ignore);
        if(collide){//collides
            hits.Add(hit);
            nextRay.origin = hit.point;
            length -= hit.distance;
            nextRay.direction = Vector3.Reflect(currRay.direction, hit.normal);
        }else{//Does not collide
            nextRay.origin += currRay.direction*length;
            length = 0;
        }//if else
        rays.Add(nextRay);
        //Adds next point to beam
        beam.positionCount++;
        beam.SetPosition(numPoint,nextRay.origin);
        rLengths.Add(length);
        vertexes.Add(Instantiate(lVGOPrefab, nextRay.origin, Quaternion.identity, beamGO.transform));
        if(collide && CheckCollisionType(hit) == "Reflective"){ //check if surface is reflective
            hits.Add(hit);
            BeamFire(numPoint+1);//Recurses ShootBeam at next point
        }//end if(CheckCollisionType(hit) == "Reflective")
    }//end BeamFire(int numPoint)

    public string CheckCollisionType(RaycastHit hit){
        if (hit.transform.gameObject.tag == null){//no collision , returns null
            return "Null";
        }else{//collsion, returns tag
            return hit.transform.gameObject.tag;
        }//end if else
    }//end CheckCollisionType(RaycastHit hit)

    //Update line renderer positions
    public void UpdatePositions(){
        int num = 0;
        foreach (Ray ray in rays){
            beam.SetPosition(num,ray.origin);
        }//end for each (Vector3 pos in points)
    }//end UpdatePositions


    public void Awake(){
        MakeBeam();
    }
    public void Update(){
        for( int i =0; i< hits.Count; i++){
            if(Physics.Raycast(rays[i+1].origin, rays{i+]}.direction,out hit,rLength[i], layerMask,QueryTriggerInteraction.Ignore);
        }
        ShootBeam();
    }
}
