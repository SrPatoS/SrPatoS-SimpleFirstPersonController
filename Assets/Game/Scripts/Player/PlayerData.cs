using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public float WalkSpeed = 3.5f;
    public float RunSpeed = 5.2f;
    public float JumpForce = 1.3f;
    public float GravityForce = 9.8f;

    [Header("Camera")]
    [Range(0.01f, 3f)] public float MouseSensitivity = 1.3f;
}
