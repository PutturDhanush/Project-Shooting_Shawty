using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSpeed;

    public float mouseX;
    public float mouseY;

    private Rigidbody cameraRb;
    private Vector3 startPosition;

    [SerializeField] private float recoilForce = 10;

    private void Start()
    {
        cameraRb = gameObject.GetComponent<Rigidbody>();
        startPosition = gameObject.transform.position;
        mouseSpeed = (2 + GameManager.instance.aimSensitivity * 2) * 33;
    }
    private void Update()
    {
        mouseX += mouseSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        mouseY += mouseSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -90, 90);
        mouseY = Mathf.Clamp(mouseY, -90, 90);

        transform.eulerAngles =new Vector3(-mouseY, mouseX, 0.0f);

    }

    public void GetRecoil()
    {
        cameraRb.AddForce(-Vector3.forward * recoilForce , ForceMode.Impulse);
        StartCoroutine(SetPushFront(0.1f));
    }

    IEnumerator SetPushFront(float gap)
    {
        yield return new WaitForSeconds(gap);
        cameraRb.velocity = new Vector3(0, 0, 0);
        transform.position = startPosition;
    }

}

