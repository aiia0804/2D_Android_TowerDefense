using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimeProject_UI
{
    public class SwipeMenu : MonoBehaviour
    {
        public GameObject scrollbar;
        private float scroll_pos = 0;
        float[] pos;
        int[] buttonNum;
        int current_button = 0;
        bool touchButton = false;
        [SerializeField] TextMeshProUGUI stageLabe;

        private void Start()
        {
            pos = new float[transform.childCount];
            buttonNum = new int[transform.childCount];

            for (int i = 0; i < buttonNum.Length; i++)
            {
                buttonNum[i] = i;
            }

        }

        void Update()
        {

            float distance = 1f / (pos.Length - 1f);
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = distance * i;
            }

            if (Input.GetMouseButton(0) && !touchButton)
            {
                scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            }

            else if (touchButton)
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[current_button], 0.1f);
                scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
            }

            else
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                    {
                        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    }
                }
            }

            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                    for (int j = 0; j < pos.Length; j++)
                    {
                        if (j != i)
                        {
                            transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.7f, 0.7f), 0.1f);
                        }
                    }
                }
            }
            if (current_button == 0)
            {
                stageLabe.text = "ゴブリン達";
            }
            else
            {
                stageLabe.text = "Comming soon..";
            }

        }

        public void ValueAfterClick(int i)
        {
            current_button = i;
            touchButton = true;
            Invoke(nameof(ResetTouch), 0.5f);

        }

        private void ResetTouch()
        {
            touchButton = false;
        }

    }
}