using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public class SkillVFXSchedule : MonoBehaviour
    {

        ISkillVFX currentVfx;

        public void StartVFX(ISkillVFX vfx)
        {
            if (currentVfx == vfx) { return; }
            if (currentVfx != null)
            {
                currentVfx.Cancel();
            }
            currentVfx = vfx;

        }
    }
}
