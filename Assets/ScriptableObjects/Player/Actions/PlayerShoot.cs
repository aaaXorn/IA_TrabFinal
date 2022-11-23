using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot", menuName = "Scriptable Object/State Machine/Player/Action/Shoot")]
public class PlayerShoot : PlayerAction
{
    

    public override void Action(PlayerControl pc)
    {
        Shoot(pc.GetCam(), Input.mousePosition, pc.transform.position);
    }

    void Shoot(Camera cam, Vector3 inputPos, Vector3 origin)
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(inputPos.x, inputPos.y, cam.transform.position.y));
        mousePos = new Vector3(mousePos.x, origin.y, mousePos.z);

        Vector3 dir = (mousePos - origin).normalized;

        
    }
}
