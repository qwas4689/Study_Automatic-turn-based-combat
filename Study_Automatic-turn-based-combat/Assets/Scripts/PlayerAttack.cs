using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
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

    private Vector3 _attackLeftPosition = new Vector3(1f, 0.5f, -1f);
    private Vector3 _position = new Vector3(-2.5f, 0.5f, -1f);

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
        attartStart = AttackCoroutine();
        StartCoroutine(attartStart);
    }

    private IEnumerator AttackCoroutine()
    {
        // 적 앞으로
        while (true)
        {
            if (transform.position.x >= _attackLeftPosition.x)
            {
                _rigidbody.velocity = Vector3.zero;
                break;
            }
            else
            {
                _rigidbody.velocity = Vector3.right * 1.5f;
            }

            yield return null;
        }

        _bullet.SetActive(true);
        yield return _waitAttack;

        // 원위치로
        while (true)
        {
            if (transform.position.x <= _position.x)
            {
                _rigidbody.velocity = Vector3.zero;
                _isAttackEnd = true;
                yield break;
            }
            else
            {
                _rigidbody.velocity = -Vector3.right * 3f;
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        AttackToEnemy.RemoveListener(Attack);
    }
}
