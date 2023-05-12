using System;

namespace ProjectG
{
    public enum EEffectType
    {
        Attack,
        DamageControl,
        DefenceControl,
        SpeedControl,
        Stun,
    }
    public enum ETargetingType
    {
        All,
        Single,
        Multi,
    }
    [Flags]
    public enum ETargetingPosition
    {
        PlayerBack      = 1,
        PlayerMiddle    = 2,
        PlayerFront     = 4,
        EnemyFront      = 8,
        EnemyMiddle     = 16,
        EnemyBack       = 32,
    }
    // 이펙트 데이터
    public class SDEffector : StaticData
    {
        // 스킬 상수
        public float constantValue;

        // 스킬 계수 %
        public float coefficientValue;

        // 효과가 돌 턴
        public int duration;

        public EEffectType effectType;

        public ETargetingType targetingType;

        public ETargetingPosition targetPosition;

    }
}
