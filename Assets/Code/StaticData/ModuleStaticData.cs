using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "ModuleData", menuName = "Static Data/Module")]
    public class ModuleStaticData : ScriptableObject
    {
        public string Name;
        public ModuleType Type;
        public float Value = 100;
    }
}