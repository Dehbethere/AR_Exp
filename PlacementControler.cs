using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementControler : MonoBehaviour
{
    [SerializeField]

    private GameObject flasks;
    public GameObject placePrefab
    {
        get 
        {
            return flasks;
        }
        set
        {
            flasks = value;
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

            Instantiate(flasks, hitPose.position, hitPose.rotation);

        }

        
    }
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

}
