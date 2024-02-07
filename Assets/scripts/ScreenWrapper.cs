using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{

    private void OnDrawGizmos()
    {
        Camera camera = Camera.main;
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Gizmos.DrawSphere(p, 0.1f);
    }
}
