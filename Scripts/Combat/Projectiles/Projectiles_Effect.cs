using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeProject_Combat
{
    public class Projectiles_Effect : MonoBehaviour
    {
        public GameObject explosionPrefab;

        public virtual void EffectAfterTouch(Vector3 position, Transform target)
        {
            GameObject explosion= Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            

            if(target.transform.position.x<this.transform.position.x)
            {
                explosion.transform.localScale=new Vector3(
                -explosion.transform.localScale.x,
                explosion.transform.localScale.y,
                explosion.transform.localScale.z);
            }
            else
            {
                explosion.transform.localScale=new Vector3(
                explosion.transform.localScale.x,
                explosion.transform.localScale.y,
                explosion.transform.localScale.z);
            }
        }


    }
}