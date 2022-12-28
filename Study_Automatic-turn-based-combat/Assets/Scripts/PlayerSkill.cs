using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    private const float FIXED_DAMAGE = 50f;

    // 스킬엔 턴 이라는 쿨타임이 존재한다

    /// <summary>
    /// 최대 체력의 20%를 회복
    /// </summary>
    public void Skill_Hill()
    {
        _playerInfo.PlayerHP += _playerInfo.PlayerHP * 0.2f;
    }

    /// <summary>
    /// 기본 대미지 50 + 자신의 방어력의 10% 의 피해
    /// </summary>
    public void Skill_DefenseProportionalAttack(Collider enemy)
    {
        float defenseProportionalAttackDamage = FIXED_DAMAGE + enemy.GetComponentInParent<PlayerInfo>().PlayerDefensivePower * 0.1f;

        _playerInfo.PlayerHP -= defenseProportionalAttackDamage;
        
    }

    /// <summary>
    /// 공격력의 130%의 피해
    /// </summary>
    public void Skill_HugeAttack(Collider enemy)
    {
        float hugeAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.3f;

        _playerInfo.PlayerHP -= hugeAttackDamage;
    }

    /// <summary>
    /// 공격력의 90%의 피해를 두번 입힘
    /// </summary>
    public void Skill_DoubleAttack(Collider enemy)
    {
        float doubleAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.8f;

        _playerInfo.PlayerHP -= doubleAttackDamage;
    }
}
