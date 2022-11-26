using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPew : MonoBehaviour
{
    [SerializeField] float _spd = 5f;

    [SerializeField] StateMachine _owner;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void SetOwner(StateMachine sm)
    {
        _owner = sm;
    }

    void Update()
    {
        rigid.velocity = transform.forward * _spd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerControl pc = other.GetComponent<PlayerControl>();
            if(pc != null && _owner != null)
            {
                _owner.bool1 = pc.GetHP().Damage();
            }

            Destroy(gameObject);
        }
    }
}
