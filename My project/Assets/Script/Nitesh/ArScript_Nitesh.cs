using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ArScript_Nitesh : MonoBehaviour
{
     public GameObject spawnedObject;
    public ARRaycastManager RaycastManager;

    void Update()
    {
    
        if(Input.touchCount>0&& Input.GetTouch(0).phase==TouchPhase.Began){
            List<ARRaycastHit> touches = new List<ARRaycastHit>();
            RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems. TrackableType.Planes);
            
            //if touch count is greater than 0 and there is already an object in the scene then move the object to the new position
            if (touches.Count >0 && spawnedObject.activeInHierarchy){
                spawnedObject.transform.position = touches[0].pose.position;
            }else{
                spawnedObject = Instantiate(spawnedObject, touches[0].pose.position, touches[0].pose.rotation);
            }
        }

    }
}

