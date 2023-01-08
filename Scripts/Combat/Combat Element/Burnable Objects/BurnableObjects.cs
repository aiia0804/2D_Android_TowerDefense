using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_CombatElement
{
    public class BurnableObjects : MonoBehaviour
    {
        float _fade = 1f;
        private Material _material;
        private bool _isBurnning = false;
        void Start()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            if (_isBurnning)
            {
                _fade -= Time.deltaTime;

                _material.SetFloat("_Fade", _fade);

                if (_fade <= 0f)
                {
                    _isBurnning = false;
                }
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Fire")
            {
                if (!_isBurnning)
                {
                    GameObject fire = ElementManager.Instance.GenerateElement(ElementType.Fire);
                    fire.transform.position = this.transform.position;
                    fire.SetActive(true);
                    _isBurnning = true;
                }
            }
        }

    }
}