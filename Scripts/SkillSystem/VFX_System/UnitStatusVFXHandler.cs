using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slimeproject_SkillSystem
{
    public class UnitStatusVFXHandler : MonoBehaviour
    {
        //To handle the vfx of skill system on each unit(include AI)

        private SpriteRenderer _spriteRenderer;
        [SerializeField] float targetHeight;
        [SerializeField] float vfxFadeOutRate;
        private float _originalHeight;
        private Vector3 _parentPos;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalHeight = transform.localPosition.y;
        }

        public void HandleVFX(Sprite vfxSprite)
        {
            _spriteRenderer.sprite = vfxSprite;
            _spriteRenderer.enabled = true;
            StartCoroutine(VFXStart());
        }

        private IEnumerator VFXStart()
        {
            float targetPos = transform.localPosition.y + targetHeight;

            while (transform.localPosition.y < targetPos - 0.1)
            {
                _spriteRenderer.color = new Color(1, 1, 1, Mathf.Lerp(_spriteRenderer.color.a, 0, vfxFadeOutRate));
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(transform.localPosition.x, targetPos, transform.localPosition.z), 0.2f);
                yield return new WaitForSeconds(Time.deltaTime * 4);
            }
            StopCoroutine(VFXStart());
            transform.localPosition = new Vector3(transform.localPosition.x, _originalHeight, transform.localPosition.z);
            _spriteRenderer.color = new Color(1, 1, 1, 1);
            _spriteRenderer.enabled = false;
        }

    }
}