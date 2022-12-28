using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Side = Defines.EBattleSide;

public class PlayerSpeed : MonoBehaviour
{
    [SerializeField] private Side _side;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerDamge _playerDamge;

    [Header("내 PlayerAttack")]
    [SerializeField] private PlayerAttack _playerAttack;

    [Header("적 PlayerAttack")]
    [SerializeField] private PlayerAttack _enemyAttack;

    private IEnumerator enumerator;

    private Action _resetSlider;

    private WaitForSeconds _wait = new WaitForSeconds(0.01f);

    private void Start()
    {
        _resetSlider = ResetSlider;
        enumerator = ActionGauge();

        StartCoroutine(enumerator);

        _playerDamge._enemyDie.RemoveListener(Stop);
        _playerDamge._enemyDie.AddListener(Stop);
    }

    private void Stop()
    {
        StopAllCoroutines();
    }

    private void ResetSlider()
    {
        _speedSlider.value = 0;
    }

    private bool AttackEnd()
    {
        return _playerAttack.IsAttackEnd;
    }

    private bool EnemyAttack()
    {
        return _enemyAttack.IsAttack;
    }

    /// <summary>
    /// 행동게이지를 올려주는 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator ActionGauge()
    {
        WaitUntil waitAttackEnd = new WaitUntil(() => AttackEnd());
        WaitUntil waitaEnemyAttack = new WaitUntil(() => EnemyAttack());

        while (true)
        {
            if (_speedSlider.value >= _speedSlider.maxValue)
            {
                _speedSlider.value = _speedSlider.maxValue;

                yield return _wait;


                _playerAttack.AttackToEnemy.Invoke();

                yield return waitAttackEnd;
                _playerAttack.IsAttackEnd = false;
                _resetSlider.Invoke();
            }
            else
            {
                _speedSlider.value += _playerInfo.PlayerSpeed * (float)0.05;
                yield return waitaEnemyAttack;
            }

            yield return _wait;
        }
    }
}
