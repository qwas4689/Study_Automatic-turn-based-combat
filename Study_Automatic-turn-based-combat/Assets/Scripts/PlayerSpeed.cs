using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerSpeed : MonoBehaviour
{
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerAttack _playerAttack;

    private IEnumerator enumerator;

    private Action _resetSlider;

    private WaitForSeconds _wait = new WaitForSeconds(0.01f);

    private void Start()
    {
        _resetSlider = ResetSlider;
        enumerator = ActionGauge();

        // StartCoroutine(enumerator);
    }

    private void ResetSlider()
    {
        _speedSlider.value = 0;
    }

    private bool AttackEnd()
    {
        return _playerAttack.IsAttackEnd;
    }

    /// <summary>
    /// �ൿ�������� �÷��ִ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    private IEnumerator ActionGauge()
    {
        WaitUntil waitUntil = new WaitUntil(() => AttackEnd());

        while (true)
        {
            _speedSlider.value += _playerInfo.PlayerSpeed * (float)0.1;

            if (_speedSlider.value >= _speedSlider.maxValue)
            {
                _speedSlider.value = _speedSlider.maxValue;

                yield return _wait;

                _playerAttack.AttackToEnemy.Invoke();

                yield return waitUntil;

                _resetSlider.Invoke();
            }

            yield return _wait;
        }
    }
}