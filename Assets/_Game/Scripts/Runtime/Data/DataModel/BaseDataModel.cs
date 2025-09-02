using System;
using UnityEngine;

namespace Runtime.Data.DataModel
{
    public abstract class BaseDataModel : ScriptableObject
    {
        public string objectName;
        #if UNITY_EDITOR
        [Attributes.ReadOnly]
        #endif
        public string id;

        protected void OnValidate()
        {
            #if UNITY_EDITOR

            if (!string.IsNullOrEmpty(id)) return;
            id = Guid.NewGuid().ToString();

            #endif
        }


        [ContextMenu("Set ID")]
        public void SetId()
        {
            id = Guid.NewGuid().ToString();
        }
        
    }
}