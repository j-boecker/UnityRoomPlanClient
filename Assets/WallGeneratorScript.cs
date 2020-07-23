using System.Collections.Generic;
using UnityEngine;

namespace Assets
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
               GenerateWalls();
            }
        }
        public void GenerateWalls()
        {
            List<WallBlock> wallBlocks = new List<WallBlock>();
            wallBlocks.Add(new WallBlock {PositionX = 0, PositionY = 0, Rotation = 90});
            wallBlocks.Add(new WallBlock { PositionX = 0, PositionY = 1, Rotation= 90 });
            wallBlocks.Add(new WallBlock { PositionX = 0, PositionY = 2, Rotation = 90 });
            wallBlocks.Add(new WallBlock { PositionX = 0, PositionY = 3, Rotation = 90 });
            wallBlocks.Add(new WallBlock { PositionX = 0, PositionY = 3, Rotation= 0 });
            wallBlocks.Add(new WallBlock { PositionX = 1, PositionY = 3, Rotation = 0});
            wallBlocks.Add(new WallBlock { PositionX = 2, PositionY = 3, Rotation = 0 });
            wallBlocks.Add(new WallBlock { PositionX = 3, PositionY = 3, Rotation = 0 });
            wallBlocks.Add(new WallBlock { PositionX = 4, PositionY = 3, Rotation = 0 });

            foreach (var wall in wallBlocks)
            {
                GameObject wallInstance = Instantiate(WallPrefab, new Vector3(wall.PositionX - 0.5f, 1, wall.PositionY), Quaternion.Euler(0,wall.Rotation,0));
                wallInstance.transform.parent = this.transform;
            }
        }
    }


    public class WallBlock
    {
        public int PositionX { get; set; }
        //z is y in unity
        public int PositionY { get; set; }
        public int Rotation { get; set; }
        public string Type { get; set; }
    }
}
