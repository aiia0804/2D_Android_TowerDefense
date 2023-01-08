using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public interface ISkillCast
    {
        void Cancel();
        void Cast(Vector3 touchPos);

    }

}