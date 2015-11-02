using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		const string projectId = "68574718-04bf-42f8-9d77-29f8a69f002f";
		UnityAnalytics.StartSDK (projectId);
		
	}
	
}