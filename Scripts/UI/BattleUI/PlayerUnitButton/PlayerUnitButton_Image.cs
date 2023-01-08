using UnityEngine;
using UnityEngine.UI;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_UI
{
    public class PlayerUnitButton_Image : MonoBehaviour
    {
        public void SetItem(Sprite image)
        {
            var iconImage = GetComponent<Image>();
            if (image == null)
            {
                iconImage.enabled = false;
#if UNITY_EDITIOR
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