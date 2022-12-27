using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [Header("플레이어의 HP를 입력 해 주세요")]
    [SerializeField] private int _playerHP;
    public int PlayerHP { get { return _playerHP; } set { _playerHP = value; }}

    private float _playerSpeed;
    public float PlayerSpeed { get { return _playerSpeed; } set { _playerSpeed = value; } }

    [Header("플레이어 공격력")]
    [SerializeField] private int _playerDamage;
    public int PlayerDamage { get { return _playerDamage; } set { _playerDamage = value; } }

    private void Awake()
    {
        SetSpeed();
    }

    private void SetSpeed()
    {
        float minSpeed = 0;
        float maxSpeed = 1;

        _playerSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
