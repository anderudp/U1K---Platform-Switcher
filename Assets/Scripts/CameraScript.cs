using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public PlayerScript player;

    // Update is called once per frame
    void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            Mathf.Lerp(Camera.main.transform.position.z, player.transform.position.z - 15f, 0.01f)
        );
    }
}
