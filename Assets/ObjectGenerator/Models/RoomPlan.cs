using System;
using System.Collections.Generic;

namespace Assets.ObjectGenerator.Models
{
    [Serializable]
    public class RoomPlan
    {
        public int id;

        public string name;

        public string description;

        public string creator;

        public int width;

        public int height;

        public List<WallBlock> wallBlocks;
    }
}
