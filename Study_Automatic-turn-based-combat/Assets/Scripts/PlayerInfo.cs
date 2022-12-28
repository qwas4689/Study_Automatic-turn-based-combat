using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [Header("�÷��̾��� HP�� �Է� �� �ּ���")]
    [SerializeField] private float _playerHP;
    public float PlayerHP { get { return _playerHP; } set { _playerHP = value; }}

    public float MaxHP { get; private set; }

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }

    [Header("�÷��̾� ���ݷ�")]
    [SerializeField] private float _playerDamage;
    public float PlayerDamage { get { return _playerDamage; } set { _playerDamage = value; } }

    [Header("�÷��̾� ����")]
    [SerializeField] private float _playerDefensivePower;
    public float PlayerDefensivePower { get { return _playerDefensivePower; } set { _playerDefensivePower = value; } }

    [SerializeField] private Slider _hpSlider;

    private void Awake()
    {
        SetSpeed();

        MaxHP = _playerHP;
    }

    private void Start()
    {
        _hpSlider.maxValue = MaxHP;
        _hpSlider.minValue = 0f;
        _hpSlider.value = MaxHP;
    }

    private void SetSpeed()
    {
        float minSpeed = 0;
        float maxSpeed = 1;

        _playerSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
