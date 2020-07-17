using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public SwitcherDimensions sd;

    public void Set3DParent()
    {
        this.transform.parent = sd.mario3d_go.transform;
        //sd.cam.orthographic = false;
    }
}
