using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowWhenNear : MonoBehaviour {

	//public float glowIntensity = 1f;
	//public float intensityIncrement = .05f;
	
	//the material we modify
	public Material material;


	private void Start() {
		// Turn off emission
 	material.DisableKeyword("_EMISSION");
	}

//turn on emission when trigger enter
	 private void OnTriggerEnter(Collider other) {
		material.EnableKeyword("_EMISSION");
 
	}


	private void OnTriggerExit(Collider other) {
		// Turn off emission
 	material.DisableKeyword("_EMISSION");
	}

/*
private IEnumerator glowObject() 
 {
 
         float curIntensity = 0.0f;
	    Color glowColor = Color.white;
         material.EnableKeyword("_EMISSION");
         material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
         // Increase intensity (fade in)
         while (curIntensity < glowIntensity)
         {
             material.SetColor("_EmissionColor", glowColor * curIntensity);
             curIntensity += intensityIncrement;
             yield return new WaitForSeconds(0.05f);
         }
         // Peak reached. Now decrease intensity (fade out)
         while (curIntensity > 0)
         {
             material.SetColor("_EmissionColor", glowColor * curIntensity);
             curIntensity -= intensityIncrement;
             yield return new WaitForSeconds(0.05f);
         }
         // Cleanup
         material.DisableKeyword("_EMISSION");
         material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
         material.SetColor("_EmissionColor", Color.black);
     }

 */
 

 }

