using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;

    [SerializeField] private Slider _speedSlider;

    [SerializeField] private PlayerSpeed _playerSpeed;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private Rigidbody _rigidbody;

    public UnityEvent AttackToEnemy;
    private WaitForSeconds _wait = new WaitForSeconds(0.1f);
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

    private void Start()
    {
        Attack();
    }

    /// <summary>
    /// 공격
    /// </summary>
    private void Attack()
    {
        IEnumerator attartStart = AttackCoroutine();
        StartCoroutine(attartStart);
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            // 앞으로 가서
            _rigidbody.velocity = Vector3.right * 1.5f;
            //transform.position = Vector3.Lerp(transform.position, _attackLeftPosition, 1f);

            // 공격하고 
            if (transform.position == _attackLeftPosition)
            {
                break;
            }
        }

        Instantiate(_bullet);
        yield return _waitAttack;

        while (true)
        {
            // 돌아오기
            _rigidbody.velocity = -Vector3.forward * 0.1f;
            //transform.position = Vector3.Lerp(transform.position, _position, 1f);

            // 다 돌아왔을 때
            if (transform.position == _position)
            {
                _isAttackEnd = true;
                break;
            }
        }

        yield break;
    }

    private void OnDisable()
    {
        AttackToEnemy.RemoveListener(Attack);
    }
}
