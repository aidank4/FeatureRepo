using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseView : MonoBehaviour
{
    private float mouseSensitivity = 300f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update

    //private Vector3 _viewInput;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

   /* private void Viewing(InputAction.CallbackContext context)
    {
        _viewInput = context.ReadValue<Vector3>();
        Vector3 mouseViewing = new Vector3(_viewInput.x, _viewInput.y, _viewInput.z);
        mouseViewing = mouseViewing.normalized;
        mouseViewing = playerBody.transform.rotation * mouseViewing;
    }*/

    // Update is called once per frame
    void Update()
    {
        Vision();
    }
    public void Vision()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
