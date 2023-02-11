using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    private const float YMin = 10.0f;
    private const float YMax = 30.0f;

    private const float XMin = -20.0f;
    private const float XMax = 20.0f;

    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;       
    
    public Rigidbody rb;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }    

    // Update is called once per frame
    void LateUpdate()
    {

        currentX += Input.GetAxis("Mouse X") * sensivity * 10  * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * 10 * Time.deltaTime;

        currentX = Mathf.Clamp(currentX, XMin, XMax);
        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = playerObj.position + rotation * Direction;

        transform.LookAt(playerObj.position);
    }

    void CameraRotation()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir, rotationSpeed * Time.deltaTime);


        playerObj.localRotation = Quaternion.Euler(horizontalInput, 0f, 0f);
        player.localRotation = Quaternion.Euler(0f, verticalInput, 0f);
    }
}
