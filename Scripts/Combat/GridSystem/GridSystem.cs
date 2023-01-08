using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlimeProject_TouchControl;

namespace SlimeProject_GridSystem
{

    public class GridSystem : MonoBehaviour
    {
        private int column;
        private int[,] gridArray;
        private Grid[] grids;
        BoxCollider myboxColider;
        [SerializeField] float adjustNum;
        [SerializeField] GameObject gridPrefab;
        [SerializeField] int defaultRow;
        private void Awake()
        {
            myboxColider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            SetUpSize();
            grids = GetComponentsInChildren<Grid>();
        }

        public void SetUpSize()
        {
            float size = myboxColider.size.y / defaultRow;
            column = Mathf.RoundToInt(myboxColider.size.x / size);
            gridArray = new int[column, defaultRow];
            SetUpGrid(size);
        }

        public void SetUpGrid(float size)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject grid = Instantiate(gridPrefab, GetWorldPosition(x, y, size),
                    Quaternion.identity);

                    grid.transform.localScale = new Vector2(size * adjustNum, size * adjustNum);
                    grid.transform.SetParent(this.transform);
                }
            }

        }

        private Vector3 GetWorldPosition(int x, int y, float size)
        {
            Vector3 startPoint = this.transform.TransformPoint(myboxColider.center + new Vector3(-myboxColider.size.x, -myboxColider.size.y) * 0.5f);
            float delatX = startPoint.x + (size / 2);
            float deltaY = startPoint.y + (size / 2);
            //Debug.Log("DELATX, DELATY: " + new Vector3(delatX, deltaY));

            //Debug.Log("X,Y: " + new Vector3(x, y));
            //Debug.Log("X,Y*size " + new Vector3(x, y) * size);
            return new Vector3(x, y) * size + new Vector3(delatX, deltaY);
            //因為是正方型 第(0,0)個-第(x,y)的方格要乘上SIZE 以保證每個方格的距離可以維持在 [size]上
        }

        public void GridDisplay()
        {
            foreach (var grid in grids)
            {
                //grid.TurnOn();
            }
        }
        public void TurnOffGrid()
        {
            foreach (var grid in grids)
            {
                //grid.TurnOff();
            }
        }



    }
}
