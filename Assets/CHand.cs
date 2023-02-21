// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Valve.VR;
// using Valve.VR.InteractionSystem;

// public class CHand : MonoBehaviour
// {
//     public Player climber = null;
//     public SteamVR_Action_Boolean grabbing;
//     private Vector3 lastPosition = Vector3.zero;
//     private GameObject currentPoint = null;
//     private List<GameObject> contactPoints = new List<GameObject>();
//     private MeshRenderer meshRenderer=null;
//     public Vector3 Delta{private set; get;} = Vector3.zero;
//     private void Awake()
//     {
//         meshRenderer=GetComponentInChildren<MeshRenderer>();
//     }
//     // Start is called before the first frame update
//     private void Start()
//     {
//         lastPosition=transform.position;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(grabbing.GetStateDown(SteamVR_Input_Sources.Any))//fix
//         {
//             GrabPoint();
//         }
//         if(grabbing.GetStateUp(SteamVR_Input_Sources.Any))//fix
//         {
//             ReleasePoint();
//         }
//     }

//     private void FixedUpdate()
//     {
//         lastPosition=transform.position;
//     }
//     private void LateUpdate()
//     {
//         Delta=lastPosition-transform.position;
//     }
//     public void GrabPoint()
//     {
//         currentPoint = Utility.GetNearest(transform.position,contactPoints);
//         if(currentPoint)    
//         {
//              climber.SetHand(this);
//             meshRenderer.enabled=false;
//         }
//     }
//     public void ReleasePoint()
//     {
//           if(currentPoint)    
//         {
//             climber.Clearhand();
//             meshRenderer.enabled=true;
//         }  
//         currentPoint=null;
//     }
//     private void OnTriggerEnter(Collider other)
//     {
//         AddPoint(other.gameObject);
//     }
//     private void AddPoint(GameObject newObject)
//     {
//         if(newObject.CompareTag("Climbable"))
//         {
//             contactPoints.Add(newObject);
//         }
//     }
//     private void OnTriggerExit(Collider other)
//     {
//         RemovePoint(other.gameObject);
//     }
//     private void RemovePoint(GameObject newObject)
//     {
//         if(newObject.CompareTag("Climbable"))
//         {
//             contactPoints.Remove(newObject);
//         }
//     }

// }
