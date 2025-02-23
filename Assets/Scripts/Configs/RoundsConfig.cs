using UnityEngine;

namespace Rounds
{
    [CreateAssetMenu(menuName = "Configs/RoundsConfig", fileName = "RoundsConfig")]
    public class RoundsConfig : ScriptableObject
    {
        [Header("Укажите длительность раунда со свиданием")]
        public float dateDuration;
    }
}