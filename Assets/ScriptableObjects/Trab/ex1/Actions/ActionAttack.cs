using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Object/State Machine/Action/Attack")]
public class ActionAttack : StateAction
{
    [SerializeField] LayerMask _playerLM = (1 << 3);
    [SerializeField] Vector3 _boxSize = Vector3.one;

    [SerializeField] float _atkDuration = 1f;

    public override void Action(StateMachine sm)
    {
        if(sm.float1 <= _atkDuration)
        {
            Collider[] hits = Physics.OverlapBox(sm.GetAtkIndicatorPos(), _boxSize/2f, sm.transform.rotation, _playerLM);

            if(hits.Length > 0)
            {
                PlayerControl pc = null;
                PlayerHealth ph = null;

                foreach(Collider col in hits)
                {
                    pc = col.GetComponent<PlayerControl>();

                    if(pc != null) ph = pc.GetHP();

                    if(ph != null) ph.Damage();
                }
            }
        }

        sm.float1 += Time.deltaTime;
    }
}
