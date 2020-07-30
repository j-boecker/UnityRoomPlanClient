using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ObjectGenerator.Interfaces
{
    interface IRestObjectGenerator
    {
        /// <summary>
        /// Get Collection of transformed Gameobjects from the Server.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="parent"></param>
        /// <param name="loadingText"></param>
        /// <returns></returns>
        void GenerateFetchedObjects(int roomId, GameObject parent, RotateText loadingText = null);

         void SetServerObjectsToUnityObjectsScale(Vector3? lambdaPosition, Vector3? lambdaScale, Vector3? lambdaRotation); 
    }
}
