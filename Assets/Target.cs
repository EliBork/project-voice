
using UnityEngine;

public class Target : MonoBehaviour {

	public void ChangePosition () {
        Vector3 positionChange = new Vector3(0, 2.0f, 0);
        this.transform.position += positionChange;
    }
}
