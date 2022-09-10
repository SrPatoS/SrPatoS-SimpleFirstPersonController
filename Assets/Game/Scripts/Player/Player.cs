using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameBehaviour
{
    protected override void Init()
    {
        MouseLock.Lock(true);
    }
}
