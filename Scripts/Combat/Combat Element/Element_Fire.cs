using UnityEngine;
using SlimeProject_ClassificationSheet;
using SlimeProject_Combat;
using SlimeProject_StatusEventSystem;

namespace SlimeProject_CombatElement
{
    public class Element_Fire : MonoBehaviour
    {
        [SerializeField] StatusType statusType;
        [SerializeField] Transform lightEffect;
        [SerializeField] float damage;

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Enemy")
            {
                other.TryGetComponent<Health>(out Health target);
                if (target.GetCurrentHP() > 0)
                {
                    target.GetComponent<StatusEventHandler>().AddStatusEvent
                    (StatusEventManager.Instance.GetStatusEvent(statusType).InitializeStatusEvent(target.gameObject), damage);
                }
            }
        }

        private void OnParticleSystemStopped()
        {
            TurnOffTheLight();
        }

        private void TurnOffTheLight()
        {
            lightEffect.gameObject.SetActive(false);
        }


    }
}