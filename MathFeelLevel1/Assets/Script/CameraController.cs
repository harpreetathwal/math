using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    public Vector3 newPosition,originalPosition;
    public Transform mainCamera;
    public Text startText;
    public void selfDestruct() { Destroy(this); }
    public void DestroyText() { Destroy(startText); }

    // Use this for initialization
    void Start () {
        mainCamera = transform.parent.transform;
        originalPosition = mainCamera.position;
        newPosition = originalPosition;
        newPosition.x = -47;
        mainCamera.position = newPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(originalPosition, newPosition) > 0.1f) {
            if (System.Math.Floor(Vector3.Distance(originalPosition, newPosition))>15)
            {
                newPosition.x += 0.03f;
                mainCamera.position = newPosition;
            }
            else if (Vector3.Distance(originalPosition, newPosition) > 0.1f)
            {
                newPosition.x += 0.08f;
                mainCamera.position = newPosition;
            }
        }
        else
        {
            startText.text = "Try your best to visualize in your head the function y = (x-1)*(x-2) and please place 3 points that would all be on this curve. Each gridline represents 1 unit.";
            Invoke("DestroyText", 3.0f);
            Invoke("selfDestruct", 3.1f);
            

        }
    }
}
