using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaypointSystem;

namespace SlimeProject_GridSystem
{
    public class RowGridSystem : MonoBehaviour
    {
        private int gridColum;
        public List<Grid> grids = new List<Grid>();
        private List<Waypoint> wayPoints = new List<Waypoint>();
        BoxCollider myboxColider;
        [SerializeField] float adjustNum;
        [SerializeField] GameObject gridPrefab;
        [SerializeField] Transform gridPool;
        private LineRenderer _lineRender;

        private void Awake()
        {
            //myboxColider = GetComponent<BoxCollider>();
            _lineRender = GetComponent<LineRenderer>();
            SetUp();
        }

        private void SetUp()
        {
            wayPoints = GetComponent<WaypointsGroup>().GetWaypointChildren();
            Vector3[] pointPos = new Vector3[wayPoints.Count];

            for (int i = 0; i < wayPoints.Count; i++)
            {
                var pos = GetWorldPosition(wayPoints[i].position);
                GameObject grid = Instantiate(gridPrefab, pos, Quaternion.identity);
                grid.transform.SetParent(gridPool.transform);
                grids.Add(grid.GetComponent<Grid>());
                SetUpHeadAndEnd(i, grid);
                pointPos[i] = pos;
            }
            _lineRender.positionCount = wayPoints.Count;
            _lineRender.SetPositions(pointPos);
        }

        private void SetUpHeadAndEnd(int x, GameObject grid)
        {
            if (x == 0)
            {
                grid.GetComponent<Grid>().TheLeftestGrid();
            }
            else if (x == wayPoints.Count - 1)
            {
                grid.GetComponent<Grid>().TheRightmostGrid();
            }
        }

        private Vector3 GetWorldPosition(Vector3 wpPosition)
        {
            Vector3 correctPos = wpPosition + this.transform.position;
            return correctPos;  
        }


    }
}