using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;
namespace Slimeproject_SkillSystem
{
    public class SKillCharge_VFXSystem : MonoBehaviour
    {
        private Vector3 startPos;
        private Vector3 endPos;
        [SerializeField] GameObject vfxParticlePrefab;
        private Color startColor;

        public void StartToMove(Vector3 startPos, Vector3 endPos, ElementType type)
        {
            this.endPos = endPos;
            this.startPos = startPos;
            switch (type)
            {
                case ElementType.NoType:
                    startColor = Color.white;
                    break;
                case ElementType.Fire:
                    startColor = Color.red;
                    break;
                case ElementType.Water:
                    startColor = Color.blue;
                    break;
                case ElementType.Wind:
                    startColor = Color.green;
                    break;
                case ElementType.Electric:
                    startColor = Color.yellow;
                    break;
            }
            GenerateParticle();
        }

        private void GenerateParticle()
        {
            var particle = Instantiate(vfxParticlePrefab, startPos, Quaternion.identity);
            var psSys = particle.GetComponent<ParticleSystem>().main;
            psSys.startColor = startColor;
            particle.GetComponent<SkillCharge_PartcileMove>().SetUp(endPos);

        }
    }
}