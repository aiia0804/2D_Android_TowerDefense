using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_ClassificationSheet;

namespace Slimeproject_Tools
{
    public class DirectionHandler
    {
        private Vector3 _startPos;
        private Vector3 _endPos;
        private Transform _target;
        private UnitType _unitType;
        private bool _firstCalled = true;
        private float originalDirec;

        public void SetData(Vector3 startPos, Vector3 endPos, Transform target, UnitType unitType)
        {
            _startPos = startPos;
            _endPos = endPos;
            _target = target;
            _unitType = unitType;
            if (_firstCalled)
            {
                _firstCalled = false;
                originalDirec = target.transform.localScale.x;
            }
            CheckDirection();
        }

        private void CheckDirection()
        {
            switch (_unitType)
            {
                case UnitType.Player:
                    if (_endPos.x <= _startPos.x)
                    {
                        _target.localScale = new Vector2(-1, 1);
                    }
                    else
                    {
                        _target.localScale = new Vector2(1, 1);
                    }
                    break;

                case UnitType.AI:
                    if (_endPos.x <= _startPos.x)
                    {
                        _target.localScale = new Vector2(1, 1);
                    }
                    else
                    {
                        _target.localScale = new Vector2(-1, 1);
                    }
                    break;
            }
        }

        public void SetDirectionBack()
        {
            _target.transform.localScale = new Vector2(originalDirec, 1);
        }
    }
}