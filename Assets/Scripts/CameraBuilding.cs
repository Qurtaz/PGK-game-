using UnityEngine;
using System.Collections;
using Helper;

public class CameraBuilding : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;

    void Update()
    {
        float rotY = -1*Input.GetAxis(InputPlayer.MOUSEY) * rotationSpeed;
        float rotX = Input.GetAxis(InputPlayer.MOUSEX) * rotationSpeed;

		transform.Rotate(rotY,rotX,0);
		transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0F);

        //transform.rotation *= Quaternion.AngleAxis(rotX, transform.up);
        //if (!((rotY > 0 && Vector3.Dot(transform.forward, Vector3.up) >= 0.99) || (rotY < 0 && Vector3.Dot(transform.forward, Vector3.up) <= -0.99))) 
           // transform.rotation *= Quaternion.AngleAxis(rotY, transform.right);
        //transform.rotation *= Quaternion.AngleAxis(0F, transform.forward);
		

    }
}
