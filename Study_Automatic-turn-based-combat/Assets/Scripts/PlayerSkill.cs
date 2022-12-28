using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerDamge _playerDamge;

    [SerializeField] private GameObject _defenseProportionalBullet;
    [SerializeField] private GameObject _hugeBullet;
    [SerializeField] private GameObject _doubleBullet;

    private IEnumerator _textUpAndChangeColor;

    private const float FIXED_DAMAGE = 50f;

    private float _defenseProportionalAttackDamage;
    private float _hugeAttackDamage;
    private float _doubleAttackDamage;

    /// <summary>
    /// 최대 체력의 20%를 회복
    /// </summary>
    public float Skill_Hill(PlayerInfo me)
    {
        me.PlayerHP += me.MaxHP * 0.2f;

        _textUpAndChangeColor = _playerDamge.TextUpAndChangeColor(Color.green);

        StartCoroutine(_textUpAndChangeColor);

        return me.MaxHP * 0.2f;
    }

    /// <summary>
    /// 기본 대미지 50 + 자신의 방어력의 10% 의 피해
    /// </summary>
    public float Skill_DefenseProportionalAttack(Collider enemy)
    {
        _defenseProportionalAttackDamage = FIXED_DAMAGE + enemy.GetComponentInParent<PlayerInfo>().PlayerDefensivePower * 0.1f;

        return _defenseProportionalAttackDamage;
    }
    public void Skill_DefenseProportionalAttack()
    {
        _defenseProportionalBullet.SetActive(true);
    }


    /// <summary>
    /// 공격력의 130%의 피해
    /// </summary>
    public float Skill_HugeAttack(Collider enemy)
    {
        _hugeAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.3f;

        return _hugeAttackDamage;
    }
    public void Skill_HugeAttack()
    {
        _hugeBullet.SetActive(true);
    }

    /// <summary>
    /// 공격력의 90%의 피해를 두번 입힘
    /// </summary>
    public float Skill_DoubleAttack(Collider enemy)
    {
        _doubleAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.8f;

        return _doubleAttackDamage;
    }
    public void Skill_DoubleAttack()
    {
        _doubleBullet.SetActive(true);
    }
}
