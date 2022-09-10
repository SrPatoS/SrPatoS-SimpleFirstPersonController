using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : GameBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _data;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _cameraBody;

    [Header("Settings")]
    [SerializeField] private float xAxisClamp = 90f;
    //Internal
    //public Vector2 Velocity {get; private set;}
    private float _sensitivity;
    private float _xRot;
    protected override void Frame()
    {
        _sensitivity = (_data.MouseSensitivity * 150f * Time.deltaTime);
        Look();
    }

    private void Look()
    {
        float x = Input.GetAxis("Mouse X") * _sensitivity;
        float y = Input.GetAxis("Mouse Y") * _sensitivity;

        _xRot -= y;
        _xRot = Mathf.Clamp(_xRot, -xAxisClamp, xAxisClamp);
        _cameraBody.localRotation = Quaternion.Euler(_xRot, 0f, 0f);

        _playerBody.Rotate(Vector3.up * x);
    }
}
