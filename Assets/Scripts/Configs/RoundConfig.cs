using Configs;
using UnityEngine;

namespace Rounds
{
    [CreateAssetMenu(menuName = "Configs/RoundsConfig", fileName = "RoundsConfig")]
    public class RoundConfig : BaseConfig
    {
        [Header("Укажите длительность раунда со свиданием")]
        public float dateDuration;
    }
}