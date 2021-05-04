using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Rigidbody bulletInstance;
    public Transform bulletContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the mouse position
        Vector2 mousePostion = Input.mousePosition;

        //Relative position compared zo Screenwidth
        float horizontalPosition = mousePostion.x / Screen.width;
        float verticalPosition = mousePostion.y / Screen.height;

        //Set the rotation of the tube to a max of 30 Degrees
        float degreeAngle = 30;
        float horizontalRotation = -degreeAngle + degreeAngle * 2 * horizontalPosition;
        float verticalRotation = -degreeAngle + degreeAngle * 2 * verticalPosition;

        //Move the tube based on Mouse Position
        gameObject.transform.localEulerAngles = new Vector3(
             75 + verticalRotation,
             0,
             horizontalRotation
         );


        //Check for Mouse clicks
        if (Input.GetMouseButtonDown(0))
        {
            //Create a new bullet instance
            Rigidbody newBulletInstance = Instantiate(bulletInstance, gameObject.transform.localPosition, Quaternion.Euler(new Vector3(0, 0, 0)), bulletContainer) as Rigidbody;
            //Static shoot power vector by now
            float shootPower = 25.0f;
            //Get the direction of the pipe as throwdirection
            Vector3 pipeVector = transform.localPosition + gameObject.transform.up * shootPower;
            //Add velocity from Vector
            newBulletInstance.velocity = pipeVector;
        }


        //check for bullets
        foreach (Transform bullet in bulletContainer) {
            if (bullet.transform.position.y < -5) {
                Destroy(bullet.gameObject);
            }
        }
    }
}
