using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private void Start() {Init();}
    private void Update() {Frame();}
    private void LateUpdate() {LateFrame();}
    private void FixedUpdate() {FixedFrame();}

    //
    protected virtual void Init() {}
    protected virtual void Frame() {}
    protected virtual void LateFrame() {}
    protected virtual void FixedFrame() {}
}
