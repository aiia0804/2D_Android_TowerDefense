using UnityEngine;
using System.Collections;

namespace Slimeproject_SkillSystem
{
    public class FadeOut : MonoBehaviour, ISkillVFX
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] float fadtOutRate;
        private SkillVFXSchedule _vFXSchedule;

        private void Awake()
        {
            _vFXSchedule = GetComponent<SkillVFXSchedule>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ProcessAreaVfx(Vector3 pos, float raidous, Sprite sprite)
        {
            _vFXSchedule.StartVFX(this);
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.gameObject.transform.position = pos;
            _spriteRenderer.transform.localScale = new Vector3(raidous, raidous, 1);
            _spriteRenderer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            StartCoroutine(VFX());
        }

        private IEnumerator VFX()
        {
            while (_spriteRenderer.color.a > 0)
            {
                SpriteRenderer sprite = _spriteRenderer.GetComponent<SpriteRenderer>();
                sprite.color = new Color(1, 1, 1, Mathf.Lerp(sprite.color.a, 0, fadtOutRate));
                yield return new WaitForEndOfFrame();
            }
        }

        public void Cancel()
        {
            StopAllCoroutines();
        }
    }
}