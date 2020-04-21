using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float Sensitivity;
    public float Speed;
    public GameObject World;

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Rotate(Time.deltaTime);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButtonDown(0))
                Select();
        }
        Move(Time.deltaTime);
    }

    private void Rotate(float deltaTime)
    {
        float rotationX = Input.GetAxis("Mouse X");
        float rotationY = Input.GetAxis("Mouse Y");
        Vector3 rotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(
            rotation.x - rotationY * Sensitivity * deltaTime,
            rotation.y + rotationX * Sensitivity * deltaTime,
            rotation.z);
    }

    private void Select()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.parent == World.transform)
            {
                Cell cell = hit.transform.GetComponent<Cell>();
                World.GetComponent<World>().Disinfect(cell);
                break;
            }
        }
    }

    private void Move(float deltaTime)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 position = transform.position;
        position += transform.forward * vertical * Speed * deltaTime;
        position += transform.right * horizontal * Speed * deltaTime;
        transform.position = position;
    }
}
