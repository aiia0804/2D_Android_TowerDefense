using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace SlimeProject_CombatElement
{
    public class ElementManager : MonoBehaviour
    {
        private static ElementManager _instance;
        public static ElementManager Instance { get { return _instance; } }
        [SerializeField] ElementDataBase[] allElementdata;
        public Dictionary<ElementType, ElementDataBase> d_AllElement =
        new Dictionary<ElementType, ElementDataBase>();

        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                if (_instance != this)
                {
                    Destroy(this.gameObject);
                }
            }
            BuildTheList();
        }

        private void BuildTheList()
        {
            foreach (var data in allElementdata)
            {
                d_AllElement[data.type] = data;
            }
        }

        public GameObject GenerateElement(ElementType type)
        {
            GameObject elementObject = Instantiate(d_AllElement[type].elementPrefab);
            elementObject.transform.SetParent(this.transform);
            return elementObject;
        }

        public int DamageCalucation(ElementType denfender, ElementType attacker)
        {
            if (d_AllElement[denfender].elementDamageList.additiveList == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("沒有放計算 LIST 記確認");
#endif
            }

            for (int i = 0; i < d_AllElement[denfender].elementDamageList.additiveList.Length; i++)
            {
                if (d_AllElement[denfender].elementDamageList.additiveList[i].type == attacker)
                {
                    return d_AllElement[denfender].elementDamageList.additiveList[i].additive;
                }
            }
            return 100;
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                // if the this is the singleton instance that is being destroyed.
                _instance = null; // set the instance to null
            }
        }
    }
}
