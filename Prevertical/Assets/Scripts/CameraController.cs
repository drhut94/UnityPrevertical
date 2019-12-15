using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    #region CinemachineVairables
    CinemachineDollyCart camCart;
    CinemachineSmoothPath cartPath;
    #endregion

    Vector3 startPoint;
    Vector3 endPoint;
    float pathDistance;

    public void Awake() {
        camCart = GetComponent<CinemachineDollyCart>();
        cartPath = FindObjectOfType<CinemachineSmoothPath>();
    }

    public void Start() {
        startPoint = cartPath.m_Waypoints[0].position;
        endPoint = cartPath.m_Waypoints[cartPath.m_Waypoints.Length - 1].position;
        pathDistance = Vector3.Distance(startPoint, endPoint);
    }

    public void Update() {
        
    }
}
