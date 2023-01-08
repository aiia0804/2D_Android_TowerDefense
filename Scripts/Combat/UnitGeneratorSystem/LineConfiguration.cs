using System.Collections.Generic;
using UnityEngine;
namespace SlimeProject_UnitGeneratorSystem
{
    [CreateAssetMenu(fileName = "LineConfiguration", menuName = "DataBase/Line/LineConfiguration", order = 0)]
    public class LineConfiguration : ScriptableObject
    {
        /// <summary>
        /// TYPE A = 只產生X點~Y點的怪
        /// TYBE B = 
        /// </summary>
        [Tooltip("Line的類型")]
        public LineType lineType;
        [Tooltip("總共產出多少後才開產")]
        public int condtionToStartGenerate;

        [Tooltip("可產生怪的id")]
        public int[] AI_ID;

        [Tooltip("一次產生的數量")]
        public int qtyForOneWave;

        [Tooltip("第一回合外CD回數, 例CD1 fW=false-> 第一回合外每回合產怪")]
        public int CDTime;

        [Tooltip("總產生數, 超過就停止")]
        public int totalQty;

        [Tooltip("特殊怪NUMBER")]
        public int[] speicalID;
        [Tooltip("特殊怪限制數")]
        public int conditionForSpecialIDGenerate;

        [Tooltip("是否為boss line")]
        public bool bossLine;




    }
}
