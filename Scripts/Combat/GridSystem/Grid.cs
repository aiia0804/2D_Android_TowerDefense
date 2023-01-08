using System.Collections;
using UnityEngine;
using SlimeProject_UI;

namespace SlimeProject_GridSystem
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] GameObject gridPicture;
        [SerializeField] Color effictiveColor;
        [SerializeField] Color defaultColor;
        [SerializeField] private bool leftestGrid = false;
        [SerializeField] private bool rightmostGrid = false;
        BoxCollider boxCollider;
        private Animator _myAnimator;
        private Battle_UI_Control _uI_Control;


        private void Awake()
        {
            _uI_Control = FindObjectOfType<Battle_UI_Control>();
            boxCollider = GetComponent<BoxCollider>();
            _myAnimator = GetComponentInChildren<Animator>();
        }
        public void SetUp(Battle_UI_Control UIControl)
        {
            _uI_Control = UIControl;
        }

        private void OnEnable()
        {
            _uI_Control.onLoadModeOn += DepolyModeOn;
            _uI_Control.onLoadModeOff += DepolyModeOff;
        }

        private void OnDisable()
        {
            _uI_Control.onLoadModeOn -= DepolyModeOn;
            _uI_Control.onLoadModeOff -= DepolyModeOff;
        }

        public void TheRightmostGrid()
        {
            rightmostGrid = true;
        }

        public void TheLeftestGrid()
        {
            leftestGrid = true;
        }

        private void DepolyModeOn()
        {
            _myAnimator.SetBool("DepolyMode", true);
        }
        private void DepolyModeOff()
        {
            _myAnimator.SetBool("DepolyMode", false);
        }

    }
}