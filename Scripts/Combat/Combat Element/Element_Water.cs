using System;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;
using SlimeProject_StatusEventSystem;

namespace SlimeProject_CombatElement
{
    public class Element_Water : MonoBehaviour
    {

        [SerializeField] GameObject electricLight;
        [SerializeField] bool onElec = false;
        [SerializeField] LayerMask layermask;
        [SerializeField] ParticleSystem fog;
        [SerializeField] ParticleSystem electric;
        [SerializeField] StatusType statusType;
        private List<GameObject> _elecList = new List<GameObject>();

        SpriteRenderer thisSprite;

        void Start()
        {
            thisSprite = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Electric")
            {
                if (!onElec)
                {
                    ElectricOn();
                }
            }

            if (other.tag == "Fire")
            {
                thisSprite.enabled = false;
                fog.gameObject.SetActive(true);
            }
        }

        private void ElectricOn()
        {
            onElec = true;
            electric.gameObject.SetActive(true);
            electricLight.SetActive(onElec);
            GetOther();
            Invoke(nameof(Return), 1f);
        }

        private void GetOther()
        {
            Collider[] hitTargets = Physics.OverlapSphere(this.transform.position, 1, layermask);

            foreach (Collider target in hitTargets)
            {
                var statusHandler = target.GetComponentInParent<StatusEventHandler>();

                if (target.tag == "Element" && !target.GetComponent<Element_Water>().onElec)
                {
                    target.GetComponent<Element_Water>().ElectricOn();
                }
                else if (target.tag == "Enemy" && !statusHandler.underStatusHandler)
                {
                    statusHandler.StatusUnderProcess();
                    if (_elecList.Contains(target.transform.parent.gameObject)) { return; }
                    else { _elecList.Add(target.transform.parent.gameObject); }
                }
                else
                {
                    continue;
                }
            }
            StartElectric();
        }

        private void StartElectric()
        {
            foreach (var obj in _elecList)
            {
                obj.GetComponent<StatusEventHandler>().AddStatusEvent
                    (StatusEventManager.Instance.GetStatusEvent(statusType).InitializeStatusEvent(obj.gameObject), 0);
            }
            _elecList.Clear();
        }

        private void Return()
        {
            onElec = false;
            electricLight.SetActive(onElec);
            electric.gameObject.SetActive(onElec);
        }

        public void KillMe()
        {
            fog.gameObject.SetActive(false);
            GetComponentInParent<WaterPool>().CheckQty();
            Destroy(this.gameObject);
        }
    }
}