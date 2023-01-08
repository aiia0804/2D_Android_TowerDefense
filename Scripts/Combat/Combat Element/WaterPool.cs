using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_CombatElement
{
    public class WaterPool : MonoBehaviour  //TODO- 可以重覆利用。改成可以被其它元素使用
    {
        [SerializeField] GameObject waterPrefab;
        [SerializeField] int qty;
        [SerializeField] float radious;
        [SerializeField] LayerMask layerMask;
        [SerializeField] ElementType type;

        private void OnEnable()
        {
            if (transform.childCount == 0)
            {
                GenerateWater();
            }
            else
            {
                return;
            }
        }
        private void GenerateWater()
        {
            int totalCount = 0;

            for (int i = 0; i < qty; i++)
            {
                Vector2 location = GetRandomArea();
                for (int j = 0; j < 3; j++)
                {
                    if (HasObject(location))
                    {
                        location = GetRandomArea();
                        totalCount++;
                    }
                    else
                    {
                        GameObject newWater = Instantiate(waterPrefab, location, Quaternion.identity);
                        newWater.transform.SetParent(this.transform);
                        j = 3;
                    }
                }
                if (totalCount >= 10)
                {
                    break;
                }
            }
            totalCount = 0;
        }

        private bool HasObject(Vector2 location)
        {
            Collider[] hitTargets = Physics.OverlapSphere(location, waterPrefab.GetComponent<SphereCollider>().radius, layerMask);
            foreach (Collider target in hitTargets)
            {
                if (target.tag == "Element")
                {
                    return true;
                }
            }
            return false;
        }

        private Vector2 GetRandomArea()
        {
            Vector2 newPos = new Vector2(this.transform.position.x + Random.Range(-radious, radious),
            this.transform.position.y + Random.Range(-radious, radious));
            return newPos;
        }

        public void CheckQty()
        {
            if (this.transform.childCount <= 1)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if (radious == 0) { return; }
            Gizmos.DrawWireSphere(this.transform.position, radious);
        }
    }
}