using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeProject_UI
{
    public class ChooseSystem_Image : MonoBehaviour
    {
        public void SetItem(Sprite image)
        {
            var iconImage = GetComponent<Image>();
            if (image == null)
            {
                iconImage.enabled = false;
#if UNITY_EDITOR
                Debug.LogWarning("似乎忘記放IMAGE 請確認。");
#endif
            }

            else
            {
                iconImage.enabled = true;
                iconImage.sprite = image;
            }
        }
    }
}