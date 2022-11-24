using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot", menuName = "Scriptable Object/State Machine/Player/Action/Shoot")]
public class PlayerShoot : PlayerAction
{
    [SerializeField] LayerMask _wallLM = (1 << 7);
    [SerializeField] float _maxRange = 30f;

    public override void Action(PlayerControl pc)
    {
        Shoot(pc, pc.GetCam(), Input.mousePosition, pc.transform.position);
    }

    void Shoot(PlayerControl pc, Camera cam, Vector3 inputPos, Vector3 origin)
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(inputPos.x, inputPos.y, cam.transform.position.y));
        mousePos = new Vector3(mousePos.x, origin.y, mousePos.z);

        Vector3 dir = (mousePos - origin).normalized;

        RaycastHit hit;

        if(Physics.Raycast(pc.GetAtkIndicatorPos(), dir, out hit, _maxRange, _wallLM))
        {
            float dist = Mathf.Clamp((hit.point - pc.GetAtkIndicatorPos()).magnitude, 0f, 30f);

            pc.SetAtkIndicatorZScale(dist);
            pc.SetAtkIndicatorRot(Quaternion.LookRotation(dir, Vector3.up));
        }
    }
}
