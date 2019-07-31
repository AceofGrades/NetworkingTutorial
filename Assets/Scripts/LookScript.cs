using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float minimumY = -90f;
    public float maximumY = 90f;

    private float yaw = 0f;
    private float pitch = 0f;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
