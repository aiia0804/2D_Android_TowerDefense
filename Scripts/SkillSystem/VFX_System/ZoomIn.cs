using UnityEngine;
using System.Collections;

namespace Slimeproject_SkillSystem
{
    public class ZoomIn : MonoBehaviour, ISkillVFX
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] float fadeInRate;
        [SerializeField] float zoomInRate;
        private SkillVFXSchedule _vFXSchedule;

        private void Awake()
        {
            _vFXSchedule = GetComponent<SkillVFXSchedule>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void ProcessVfx(Vector3 pos, float raidous, Sprite sprite)
        {
            _vFXSchedule.StartVFX(this);
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.gameObject.transform.position = pos;
            _spriteRenderer.transform.localScale = new Vector3(raidous, raidous, 1);
            _spriteRenderer.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
            StartCoroutine(VFX());
        }

        private IEnumerator VFX()
        {
            while (_spriteRenderer.color.a < 1)
            {
                _spriteRenderer.color = new Color(1, 1, 1, Mathf.Lerp(_spriteRenderer.color.a, 1, fadeInRate));
                _spriteRenderer.transform.localScale = Vector3.Lerp(_spriteRenderer.transform.localScale,
                                                                    new Vector3(0.5f, 0.5f, 1f),
                                                                    zoomInRate);
                yield return new WaitForEndOfFrame();
            }
            _spriteRenderer.enabled = false;
        }

        public void Cancel()
        {
            StopAllCoroutines();
        }
    }
}