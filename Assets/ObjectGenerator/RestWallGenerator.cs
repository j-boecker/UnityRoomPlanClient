using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Assets.ObjectGenerator.Interfaces;
using Assets.ObjectGenerator.Models;
using Proyecto26;
using RSG;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Assets.ObjectGenerator
{
    public class RestWallGenerator : MonoBehaviour, IRestObjectGenerator
    {
        private readonly GameObject _wallPrefab;
        private readonly string _urlBase;
        private float scalePosX;
        private float scalePosY;
        private float scaleWitdh;
        private float scaleLength;

        public RestWallGenerator(GameObject prefab, string urlBase)
        {
            _wallPrefab = prefab;
            _urlBase = urlBase;
        }
        public void GenerateFetchedObjects(int roomId, GameObject parent)
        {
            RestClient.Get<RoomPlan>($"{_urlBase}/RoomPlans/{roomId}").Then(roomPlan =>
            {
                foreach (var wallBlock in roomPlan.wallBlocks)
                {
                    GameObject wallInstance = Instantiate(_wallPrefab, new Vector3(wallBlock.positionX * scalePosX, 0, wallBlock.positionY * scalePosY),
                        Quaternion.Euler(0, wallBlock.rotation, 0));
                   // wallInstance.transform.localScale = new Vector3(1f, 1, 1f);

                    wallInstance.transform.parent = parent.transform;
                }
                //move parent root
                parent.transform.Translate(-1.5f, -0.5f, -1.5f);
            }).Catch(response =>  EditorUtility.DisplayDialog("Error", response.Message, "Ok"));
        }

        public void SetServerObjectsToUnityObjectsScale(Vector3? lambdaPosition, Vector3? lambdaScale, Vector3? lambdaRotation)
        {
            if (lambdaPosition != null)
            {
                scalePosX = lambdaPosition.Value.x;
                scalePosY = lambdaPosition.Value.y;
            }

            if (lambdaScale != null)
            {
                scaleLength = lambdaScale.Value.x;
                scaleWitdh = lambdaScale.Value.y;
            }
        }
    }
}
