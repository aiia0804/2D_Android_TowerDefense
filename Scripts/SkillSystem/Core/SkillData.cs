using UnityEngine;

namespace Slimeproject_SkillSystem
{

    [CreateAssetMenu(fileName = "SkillData", menuName = "DataBase/Skill/SkillData", order = 0)]
    public class SkillData : ScriptableObject
    {
        public string skillName;
        public int xpUsage;
        [TextArea(5, 5)]
        public string skillDescr;
        public SkillType skillType;
        public float parameter1;
        public Sprite icon;
        public Sprite vfxSprite;


    }
}