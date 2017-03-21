using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;
    private Camera _camera;

	// Use this for initialization
	void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
        if (body != null) {
            body.freezeRotation = true;
        }
        if (_camera != null) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
	}
}
