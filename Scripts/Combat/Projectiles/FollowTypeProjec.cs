using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_Combat
{
    public class FollowTypeProjec : MonoBehaviour
    {
        private GameObject _target;
        private float _damage;
        [SerializeField] ElementType elementType;
        [SerializeField] float flyingSpeed;
        Vector3 flyingDirection;
        private string _targetLayer;

        private void FixedUpdate()
        {
            ProcessingMoving();
        }

        private void ProcessingMoving()
        {
            transform.position += flyingDirection * Time.deltaTime * flyingSpeed;
        }

        private void AdjustDirction(Vector3 target)
        {
            flyingDirection = (target - this.transform.position).normalized;
            Vector3 dir = target - this.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == _targetLayer) { return; }

            var target = other.transform.parent;
            if (_target == null) { return; }
            if (target.gameObject != _target) { return; }
            target.GetComponent<Health>().TakeElementDamage(_damage, elementType);
            DestroyIt();
        }

        public void SetUp(GameObject target, float damage, string targetLayer)
        {
            if (target == null) { DestroyIt(); }
            try
            {
                _target = target;
                _damage = damage;
                _targetLayer = targetLayer;
                AdjustDirction(target.transform.position);
            }
            catch
            {
                DestroyIt();
            }
            Destroy(this.gameObject, 5f);
        }

        private void DestroyIt()
        {
            Destroy(this.gameObject);
        }
    }
}