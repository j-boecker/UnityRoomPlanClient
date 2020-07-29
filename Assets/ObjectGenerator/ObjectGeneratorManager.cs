using System;
using Assets.ObjectGenerator.Interfaces;
using UnityEngine;

namespace Assets.ObjectGenerator
{
    public class ObjectGeneratorManager : MonoBehaviour
    {
        public string UrlBase = "https://arwebapiproviderdemo.azurewebsites.net/api";
        public GameObject WallPrefab;
        private IRestObjectGenerator _wallGenerator;

        private int CurrentRoomId = 1;
        // Start is called before the first frame update
        void Start()
        {
            _wallGenerator = new RestWallGenerator(WallPrefab, UrlBase);
            //_wallGenerator.SetServerObjectsToUnityObjectsScale(new Vector3(0.01f, 0.01f, 0.01f), Vector3.one, Vector3.one );
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void NextRoom()
        {
            CurrentRoomId++;
        }

        public void GenerateWalls()
        {
            //clear previous childs
            foreach (Transform child in this.transform)
            { 
                GameObject.Destroy(child.gameObject);
            }
            _wallGenerator.SetServerObjectsToUnityObjectsScale(new Vector3(0.1f, 0.1f, 0.1f), Vector3.one, Vector3.one);
            _wallGenerator.GenerateFetchedObjects(CurrentRoomId, this.gameObject);
        }
    }
}
