using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;

public class TrackedPlaneGenerator : MonoBehaviour {

	private List<DetectedPlane> newPlanes = new List<DetectedPlane>();
	//private List<TrackedPlane> allPlanes = new List<TrackedPlane>();
	public GameObject trackedPlanePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Session.Status != SessionStatus.Tracking) {
			return;
		}

		Session.GetTrackables<DetectedPlane>(newPlanes, TrackableQueryFilter.New);

		for (int i = 0; i < newPlanes.Count; i++) {
			GameObject planeObject = Instantiate(trackedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
			planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(newPlanes[i]);
		}
	}
}
