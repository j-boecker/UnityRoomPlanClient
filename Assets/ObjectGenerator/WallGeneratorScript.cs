using System;
using System.Collections.Generic;
using Assets.ObjectGenerator.Models;
using Proyecto26;
using UnityEditor;
using UnityEngine;

namespace Assets.ObjectGenerator
{
    public class WallGeneratorScript : MonoBehaviour
    {
        public GameObject WallPrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("o"))
            {
                GetRestResponse();
              //  GenerateWalls();
            }
        }

        public void GenerateWalls()
        {
            List<WallBlock2> wallBlocks = new List<WallBlock2>();
            wallBlocks.Add(new WallBlock2 {PositionX = 0, PositionY = 0, Rotation = 90});
            wallBlocks.Add(new WallBlock2 {PositionX = 0, PositionY = 1, Rotation = 90});
            wallBlocks.Add(new WallBlock2 {PositionX = 0, PositionY = 2, Rotation = 90});
            wallBlocks.Add(new WallBlock2 {PositionX = 0, PositionY = 3, Rotation = 90});
            wallBlocks.Add(new WallBlock2 {PositionX = 1, PositionY = 3, Rotation = 0});
            wallBlocks.Add(new WallBlock2 {PositionX = 2, PositionY = 3, Rotation = 0});
            wallBlocks.Add(new WallBlock2 {PositionX = 3, PositionY = 3, Rotation = 0});
            wallBlocks.Add(new WallBlock2 {PositionX = 4, PositionY = 3, Rotation = 0});

            foreach (var wall in wallBlocks)
            {
                GameObject wallInstance = Instantiate(WallPrefab, new Vector3(wall.PositionX - 0.5f, 1, wall.PositionY),
                    Quaternion.Euler(0, wall.Rotation, 0));
                wallInstance.transform.parent = this.transform;
            }
        }

        public void GetRestResponse()
        {
            RestClient.Get<RoomPlan>("https://arwebapiproviderdemo.azurewebsites.net/api/RoomPlans/1").Then(room =>
            {
                var roomModel = JsonUtility.ToJson(room, true);
                EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(room, true), "Ok");
                 
            });
        }

        public void GetRestResponse2()
        {
            RestClient.Get("https://arwebapiproviderdemo.azurewebsites.net/api/values").Then(room =>
            {
                EditorUtility.DisplayDialog("JSON Array", room.Text, "Ok");

            });
        }


        [Serializable]
        public class WallBlock2
        {
            public int Id { get; set; }
            public float PositionX { get; set; }
            public float PositionY { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }
            public int Rotation { get; set; }
        }
    }
}
