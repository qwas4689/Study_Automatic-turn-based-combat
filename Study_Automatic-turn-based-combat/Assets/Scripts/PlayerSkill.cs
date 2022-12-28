using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    private const float FIXED_DAMAGE = 50f;

    // ��ų�� �� �̶�� ��Ÿ���� �����Ѵ�

    /// <summary>
    /// �ִ� ü���� 20%�� ȸ��
    /// </summary>
    public void Skill_Hill()
    {
        _playerInfo.PlayerHP += _playerInfo.PlayerHP * 0.2f;
    }

    /// <summary>
    /// �⺻ ����� 50 + �ڽ��� ������ 10% �� ����
    /// </summary>
    public void Skill_DefenseProportionalAttack(Collider enemy)
    {
        float defenseProportionalAttackDamage = FIXED_DAMAGE + enemy.GetComponentInParent<PlayerInfo>().PlayerDefensivePower * 0.1f;

        _playerInfo.PlayerHP -= defenseProportionalAttackDamage;
        
    }

    /// <summary>
    /// ���ݷ��� 130%�� ����
    /// </summary>
    public void Skill_HugeAttack(Collider enemy)
    {
        float hugeAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.3f;

        _playerInfo.PlayerHP -= hugeAttackDamage;
    }

    /// <summary>
    /// ���ݷ��� 90%�� ���ظ� �ι� ����
    /// </summary>
    public void Skill_DoubleAttack(Collider enemy)
    {
        float doubleAttackDamage = enemy.GetComponentInParent<PlayerInfo>().PlayerDamage * 1.8f;

        _playerInfo.PlayerHP -= doubleAttackDamage;
    }
}
