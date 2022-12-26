using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Side = Defines.EBattleSide;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Side _side;
    [SerializeField] private Slider _speedSlider;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerSpeed _playerSpeed;

    public UnityEvent AttackToEnemy;

    private IEnumerator attartStart;
    private WaitForSeconds _waitAttack = new WaitForSeconds(1f);

    private bool _isAttackEnd;
    public bool IsAttackEnd { get { return _isAttackEnd; } set { _isAttackEnd = value; } }

    private bool _isAttack = true;
    public bool IsAttack { get { return _isAttack; } set { _isAttack = value; } }

    private Vector3 _attackPos = new Vector3(1f, 0f, 0f);
    private Vector3 _playerPos = new Vector3(-2.5f, 0f, 0f);

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
                _rigidbody.velocity = Vector3.right * 3f;
            }

            yield return null;
        }

        _bullet.SetActive(true);
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
                _rigidbody.velocity = -Vector3.right * 2f;
            }

            yield return null;
        }
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
                _rigidbody.velocity = Vector3.left * 3f;
            }

            yield return null;
        }

        _bullet.SetActive(true);
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
                _rigidbody.velocity = -Vector3.left * 2f;
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        AttackToEnemy.RemoveListener(Attack);
    }
}
