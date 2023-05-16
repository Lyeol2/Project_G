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
        None            = 1,
        PlayerBack      = 2,
        PlayerMiddle    = 4,
        PlayerFront     = 8,
        EnemyFront      = 16,
        EnemyMiddle     = 32,
        EnemyBack       = 64,
        Last            = 128,
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

        //public ETargetingPosition targetPosition;

    }
}
