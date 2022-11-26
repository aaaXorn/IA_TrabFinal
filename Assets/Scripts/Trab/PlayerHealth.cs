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

    [Tooltip("Max HP.")]
    [SerializeField] int _maxHP = 2;
    int _HP;

    Vector3 _startPos;

    void Awake()
    {
        _mat = _render.material;
    }

    void Start()
    {
        _startPos = transform.position;

        _HP = _maxHP;
    }

    public bool IsHurt()
    {
        return _isHurt;
    }

    public bool Damage()
    {
        if(_invul) return false;

        _curr_hurtTime = _hurtTime;
        _HP--;

        if(_HP <= 0)
        {
            transform.position = _startPos;
            _HP = _maxHP;

            return true;
        }
        StartCoroutine("DamageTimer");
        return false;
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
