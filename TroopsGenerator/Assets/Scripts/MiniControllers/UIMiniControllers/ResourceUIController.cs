using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TroopsGenerator
{
    public class ResourceUIController : MonoBehaviour
    {
        [SerializeField]
        Text ResourceTitleTxt;
        [SerializeField]
        Text ResourcesCountTxt;
        #region Public Methods
        /// <summary>
        /// Call this after Instantiation to intialze the UI componenets
        /// </summary>
        /// <param name="title"></param>
        /// <param name="count"></param>
        public void Initialize(string title, int count)
        {
            ResourceTitleTxt.text = title;
            ResourcesCountTxt.text = count.ToString();
        }

        #endregion
    }
}