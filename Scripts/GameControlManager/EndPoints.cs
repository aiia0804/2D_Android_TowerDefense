using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_UI;
using SlimeProject_AI;


namespace SlimeProject_GameControlSystem
{
    public class EndPoints : MonoBehaviour
    {
        [SerializeField] HeartDisplay heartDisplay;
        [SerializeField] List<AI_Base> unitLists = new List<AI_Base>();

        private void Awake()
        {
            heartDisplay = FindObjectOfType<HeartDisplay>();
        }

        private void OnTriggerEnter(Collider other)
        {
            print(other.transform.parent.name);
            if (other.tag == "Enemy")
            {
                unitLists.Add(other.GetComponentInParent<AI_Base>());
                StartCoroutine(CheckEnd());
            }
        }

        private IEnumerator CheckEnd()
        {
            while (unitLists.Count > 0)
            {
                for (int i = 0; i < unitLists.Count; i++)
                {
                    if (unitLists[i] == null) { unitLists.Remove(unitLists[i]); continue; }
                    if (unitLists[i].isEnd)
                    {
                        var points = unitLists[i].dataBase.damageToPoints;
                        Destroy(unitLists[i].gameObject);
                        unitLists.RemoveAt(i);
                        print(points);
                        heartDisplay.TakeDamage(points);
                    }
                }
                yield return new WaitForEndOfFrame();
            }
            StopCoroutine(CheckEnd());
        }

    }
}