using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using Side = Defines.EBattleSide;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Side _side;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerSpeed _playerSpeed;
    [SerializeField] private PlayerSkill _playerSkill;

    [Header("플레이어1의 스킬 쿨타임을 입력 해 주세요")]
    [SerializeField] private int[] _player1SkillCoolTime;
    public int[] Player1SkillCoolTime { get { return _player1SkillCoolTime; } set { _player1SkillCoolTime = value; } }

    [Header("플레이어2의 스킬 쿨타임을 입력 해 주세요")]
    [SerializeField] private int[] _player2SkillCoolTime;
    public int[] Player2SkillCoolTime { get { return _player2SkillCoolTime; } set { _player2SkillCoolTime = value; } }

    public UnityEvent AttackToEnemy;

    private IEnumerator attartStart;
    private WaitForSeconds _waitAttack = new WaitForSeconds(1f);

    private bool _isAttackEnd;
    public bool IsAttackEnd { get { return _isAttackEnd; } set { _isAttackEnd = value; } }

    private bool _isAttack = true;
    public bool IsAttack { get { return _isAttack; } set { _isAttack = value; } }

    private const int SKILL_1 = 0;
    private const int SKILL_2 = 1;

    private Vector3 _attackPos = new Vector3(1f, 0f, 0f);
    private Vector3 _playerPos = new Vector3(-2.5f, 0f, 0f);

    private float _moveAttackSpeed = 3f;
    private float _moveBackSpeed = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
       
        AttackToEnemy.RemoveListener(Attack);
        AttackToEnemy.AddListener(Attack);
    }

    /// <summary>
    /// 공격
    /// </summary>
    private void Attack()
    {
        _isAttack = false;
        attartStart = _side == 0 ? LeftPlayerAttack() : RightPlayerAttack();
        StartCoroutine(attartStart);
    }

    private IEnumerator LeftPlayerAttack()
    {
        // 적 앞으로
        while (true)
        {
            if (transform.position.x >= _attackPos.x)
            {
                _rigidbody.velocity = Vector3.zero;
                break;
            }
            else
            {
                _rigidbody.velocity = Vector3.right * _moveAttackSpeed;
            }

            yield return null;
        }

        if (SetSkillCoolTime(_player1SkillCoolTime))
        {
            if (_player1SkillCoolTime[SKILL_2] == 0)
            {
                _playerSkill.Skill_DefenseProportionalAttack();

                _player1SkillCoolTime[SKILL_2] = 3;
            }
            else if (_player1SkillCoolTime[SKILL_1] == 0)
            {
                _playerSkill.Skill_Hill(_playerInfo);

                _player1SkillCoolTime[SKILL_1] = 3;
            }
        }
        else
        {
            _bullet.SetActive(true);
        }

        yield return _waitAttack;

        // 원위치로
        while (true)
        {
            if (transform.position.x <= _playerPos.x)
            {
                _rigidbody.velocity = Vector3.zero;
                _isAttackEnd = true;
                _isAttack = true;
                yield break;
            }
            else
            {
                _rigidbody.velocity = -Vector3.right * _moveBackSpeed;
            }

            yield return null;
        }
    }

    /// <summary>
    /// 플레이어 스킬 쿨타임 감소
    /// </summary>
    /// <param name="player"></param>
    private bool SetSkillCoolTime(int[] player)
    {
        bool isOn = false;
        for (int i = 0; i < player.Length; ++i)
        {
            --player[i];

            if (player[i] <= 0)
            {
                player[i] = 0;
            }
            if (player[i] == 0)
            {
                isOn = true;
            }
        }

        return isOn;
    }

    private IEnumerator RightPlayerAttack()
    {
        // 적 앞으로
        while (true)
        {
            if (transform.position.x <= -_attackPos.x)
            {
                _rigidbody.velocity = Vector3.zero;
                break;
            }
            else
            {
                _rigidbody.velocity = Vector3.left * _moveAttackSpeed;
            }

            yield return null;
        }

        if (SetSkillCoolTime(_player2SkillCoolTime))
        {
            if (_player2SkillCoolTime[SKILL_2] == 0)
            {
                _playerSkill.Skill_DoubleAttack();

                _player2SkillCoolTime[SKILL_2] = 4;
            }
            else if (_player2SkillCoolTime[SKILL_1] == 0)
            {
                _playerSkill.Skill_HugeAttack();

                _player2SkillCoolTime[SKILL_1] = 2;
            }
        }
        else
        {
            _bullet.SetActive(true);
        }

        yield return _waitAttack;

        // 원위치로
        while (true)
        {
            if (transform.position.x >= -_playerPos.x)
            {
                _rigidbody.velocity = Vector3.zero;
                _isAttackEnd = true;
                _isAttack = true;
                yield break;
            }
            else
            {
                _rigidbody.velocity = -Vector3.left * _moveBackSpeed;
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        AttackToEnemy.RemoveListener(Attack);
    }
}
