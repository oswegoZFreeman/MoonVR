using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClip : MonoBehaviour
{
     RaycastHit ray;
 Player player;
 LayerMask worldLayerMask;
 public float clipOffset = 0.1f;
 public Vector3 clipCheckOffset = new Vector3(0, 1, 0);
 void Update()
 {

     Debug.DrawRay(GetComponent<Camera>().transform.position, (
   (player.transform.position + clipCheckOffset) -
     GetComponent<Camera>().transform.position));

     if (
     Physics.Raycast(GetComponent<Camera>().transform.position, (player.transform.position + clipCheckOffset) -
     GetComponent<Camera>().transform.position, out ray, -GetComponent<Camera>().transform.localPosition.z - 0.5f,
     worldLayerMask)
     )
     {
         GetComponent<Camera>().transform.position = ray.point + ((player.transform.position + clipCheckOffset) -
         GetComponent<Camera>().transform.position).normalized * clipOffset;
         Debug.Log("hit something");
     }



 }
}
