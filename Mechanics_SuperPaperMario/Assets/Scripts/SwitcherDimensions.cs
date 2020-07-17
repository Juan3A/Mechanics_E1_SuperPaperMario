using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherDimensions : MonoBehaviour
{
    public enum type { mario_2d, mario_3d };
    public type tipo;
    public float speed;
    public float jumpforce;
    public GameObject mario2d_go;
    public GameObject mario3d_go;
    public Camera cam;
    public GameObject cam_follower;
    public Animator anim;
    public bool flipX;

    private void Awake()
    {
        cam_follower.transform.parent = mario2d_go.transform;
        cam.orthographic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tipo = (tipo == type.mario_2d) ? type.mario_3d : type.mario_2d;

            CheckTipo();
        }
    }

    public void CheckTipo()
    {
        switch (tipo)
        {
            case type.mario_2d:
                mario2d_go.transform.position = mario3d_go.transform.position;
                mario2d_go.SetActive(true);
                mario3d_go.SetActive(false);
                cam_follower.transform.parent = mario2d_go.transform;
                cam.orthographic = true;
                anim.SetTrigger("out");
                break;
            case type.mario_3d:
                mario3d_go.transform.position = mario2d_go.transform.position;
                cam_follower.transform.parent = null;
                mario3d_go.SetActive(true);
                mario2d_go.SetActive(false);
                cam.orthographic = false;
                anim.SetTrigger("in");
                break;
        }
    }
}
