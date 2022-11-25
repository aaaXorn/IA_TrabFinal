using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("Time the player is stunned after a hit.")]
    [SerializeField] float _hurtTime = 0.75f;
    float _curr_hurtTime = 0f;
    bool _isHurt = false;
    bool _invul = false;

    [Tooltip("Default and damaged player colors.")]
    [SerializeField] Color[] _mat_colors;
    [Tooltip("Renderer that will have its material color changed.")]
    [SerializeField] Renderer _render;
    Material _mat;

    void Awake()
    {
        _mat = _render.material;
    }

    public bool IsHurt()
    {
        return _isHurt;
    }

    public void Damage()
    {
        if(_invul) return;

        _curr_hurtTime = _hurtTime;

        StartCoroutine("DamageTimer");
    }

    private IEnumerator DamageTimer()
    {
        _invul = true;

        _isHurt = true;
        _mat.SetColor("_BaseColor", _mat_colors[1]);

        while(_curr_hurtTime > 0)
        {
            _curr_hurtTime -= 0.167f;
            yield return new WaitForSeconds(0.167f);
        }

        _isHurt = false;
        _mat.SetColor("_BaseColor", _mat_colors[0]);

        while(_curr_hurtTime > -_hurtTime)
        {
            _curr_hurtTime -= 0.167f;
            yield return new WaitForSeconds(0.167f);
        }

        _invul = false;
    }
}
