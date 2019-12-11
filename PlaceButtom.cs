using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceButtom : MonoBehaviour
{
    [SerializeField]

    private GameObject Clabs;
    public GameObject Flabs;
    public GameObject Qlabs
    
    {
        get 
        {
            return Clabs;
        }
        set
        {
            Clabs = value;
        }


    }
    private ARRaycastManager arRaycastMenager;
    void Awake(){
        arRaycastMenager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTTouchPosition(out Vector2 touchPosition){
        if(Input.touchCount > 0){
            touchPosition = Input.GetTouch( 0).position;
            return true;
        }
        touchPosition = default;
        return false;

    }

    
    void Update()
    {
        if(!TryGetTTouchPosition(out Vector2 touchPosition))
            return;

        if(arRaycastMenager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            Instantiate(Clabs, hitPose.position, hitPose.rotation);

        }

        
    }
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

}