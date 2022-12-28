using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class PlayerDamge : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private PlayerSpeed _playerSpeed;
    [SerializeField] private PlayerSkill _playerSkill;

    public UnityEvent _enemyDie;

    private IEnumerator _textUpAndChangeColor;

    private Vector2 _textPos = new Vector2(0f, 0.3f);
    private Vector2 _textMoveVector = new Vector2(0f, 0.002f);
    private Color _color = new Color(0f, 0f, 0f, 0.002f);

    private Action _hit;

    private void Start()
    {
        _hit = Hit;
    }

    private void Hit()
    {
        _textUpAndChangeColor = TextUpAndChangeColor(Color.black);
        StartCoroutine(_textUpAndChangeColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        float myHitDamage;

        if (other.tag.Contains("Bullet"))
        {
            myHitDamage = other.GetComponentInParent<PlayerInfo>().PlayerDamage - _playerInfo.PlayerDefensivePower;

            _playerInfo.PlayerHP -= myHitDamage;
            _hpSlider.value = _playerInfo.PlayerHP;
            _damageText.text = myHitDamage.ToString();
            _hit.Invoke();

            if (_playerInfo.PlayerHP <= 0)
            {
                other.GetComponentInParent<PlayerSpeed>().StopAllCoroutines();
                _enemyDie.Invoke();
            }
        }

        else if (other.tag.Contains("DefenseProportionalAttack"))
        {
            myHitDamage = _playerSkill.Skill_DefenseProportionalAttack(other) - _playerInfo.PlayerDefensivePower;

            _playerInfo.PlayerHP -= myHitDamage;
            _hpSlider.value = _playerInfo.PlayerHP;
            _damageText.text = myHitDamage.ToString();
            _hit.Invoke();

            if (_playerInfo.PlayerHP <= 0)
            {
                other.GetComponentInParent<PlayerSpeed>().StopAllCoroutines();
                _enemyDie.Invoke();
            }
        }

        else if (other.tag.Contains("HugeAttack"))
        {
            myHitDamage = _playerSkill.Skill_HugeAttack(other) - _playerInfo.PlayerDefensivePower;

            _playerInfo.PlayerHP -= myHitDamage;
            _hpSlider.value = _playerInfo.PlayerHP;
            _damageText.text = myHitDamage.ToString();
            _hit.Invoke();

            if (_playerInfo.PlayerHP <= 0)
            {
                other.GetComponentInParent<PlayerSpeed>().StopAllCoroutines();
                _enemyDie.Invoke();
            }
        }

        else if (other.tag.Contains("DoubleAttack"))
        {
            myHitDamage = _playerSkill.Skill_DoubleAttack(other) - _playerInfo.PlayerDefensivePower;

            _playerInfo.PlayerHP -= myHitDamage;
            _hpSlider.value = _playerInfo.PlayerHP;
            _damageText.text = myHitDamage.ToString();
            _hit.Invoke();

            if (_playerInfo.PlayerHP <= 0)
            {
                other.GetComponentInParent<PlayerSpeed>().StopAllCoroutines();
                _enemyDie.Invoke();
            }
        }
    }

    public IEnumerator TextUpAndChangeColor(Color color)
    {
        while (true)
        {
            if (_damageText.color.a <= 0f)
            {
                _damageText.rectTransform.anchoredPosition = _textPos;
                _damageText.color = color;
                _damageText.text = null;
                yield break;
            }
            else
            {
                _damageText.rectTransform.anchoredPosition += _textMoveVector;
                _damageText.color -= _color;
            }
            
            yield return null;
        }
    }
}
