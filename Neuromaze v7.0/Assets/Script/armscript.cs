using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class armscript : MonoBehaviour
{
    GameObject cam;
    GameObject arms;
    float rotSpeed=15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float X = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        Y = Mathf.Clamp(Y, -89.5f, 89.5f);
        cam.transform.localRotation = Quaternion.Euler(Y, 0f, 0f);
        arms.transform.localRotation = Quaternion.Euler(Y, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, X, 0f);
    }
}
*/

/*public class armscript : MonoBehaviour {
    GameObject cam;
    GameObject arms;
    public float rotSpeed;

    // Start is called before the first frame update
    void Start() {
cam = GameObject.Find("Main Camera");
arms=GameObject.Find("Arms");
    }

    // Update is called once per frame
    void Update() {
        float X = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        Y = Mathf.Clamp(Y, -89.5f, 89.5f);

        Vector3 camEulerAngles = cam.transform.localEulerAngles;
        camEulerAngles.x += -Y;

        cam.transform.localEulerAngles = camEulerAngles;
        arms.transform.localEulerAngles = camEulerAngles;
        transform.localRotation = Quaternion.Euler(0f, cam.transform.localEulerAngles.y, 0f);
    }
}*/


/*public class armscript : MonoBehaviour {
     GameObject cam;
     GameObject arms;
    public float sensitivity = 2f;

void Start(){

    cam = GameObject.Find("Main Camera");
arms=GameObject.Find("Arms");
}
    // Update is called once per frame
    void Update() {
        // Get the mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the arms based on mouse movement
        Vector3 armRotation = arms.transform.localEulerAngles;
        armRotation.x -= mouseY;
        armRotation.y += mouseX;
        arms.transform.localEulerAngles = armRotation;

        // Rotate the body based on mouse movement
        Vector3 bodyRotation = transform.localEulerAngles;
        bodyRotation.y += mouseX;
        transform.localEulerAngles = bodyRotation;
    }
}

*/
public class armscript : MonoBehaviour {
     GameObject cam;
     GameObject arms;
    public float sensitivity = 2f;
    public float armVerticalOffset = 1f;
void Start(){

    cam = GameObject.Find("Main Camera");
arms=GameObject.Find("Arms");
}
    // Update is called once per frame
    void Update() {
        // Get the mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the arms based on mouse movement
        Vector3 armRotation = arms.transform.localEulerAngles;
        armRotation.x = Mathf.Clamp(armRotation.x - mouseY, -89.5f, 89.5f);
        armRotation.y += mouseX;
        arms.transform.localEulerAngles = armRotation;

        // Calculate the offset for vertical movement
        float offset = mouseY * armVerticalOffset;

        // Move the arms down based on the vertical offset
        Vector3 armPosition = arms.transform.localPosition;
        armPosition.y -= offset;
        arms.transform.localPosition = armPosition;
    }
}

