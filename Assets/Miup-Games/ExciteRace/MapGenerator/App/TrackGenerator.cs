using UnityEngine;
using System.Collections;
using System.Diagnostics;

namespace Miup.MapGenerators.App
{
    [ExecuteInEditMode]
    public class TrackGenerator : MonoBehaviour
    {
        enum PATERN_TYPE
        {
            SECUENCE,
            RANDOM}
        ;

        [SerializeField] GameObject[] _trackPrefabs;
        [SerializeField] PATERN_TYPE _patern = PATERN_TYPE.RANDOM;

        [SerializeField] int _numberOfElements;

        [SerializeField] Vector3 _distanceVector;
        [SerializeField] Vector3 _initialPosition;

        [SerializeField] bool 
            _generate, 
            _clearTrack;

        // Update is called once per frame
        void Update()
        {
            if (_clearTrack)
            {
                ClearTrack(this.transform);
                _clearTrack = false;
            }

            if (_generate)
            {
                if (_trackPrefabs.Length >= 0)
                {                        
                    GenerateTrack(this.transform, _trackPrefabs, _numberOfElements, _initialPosition, _distanceVector, _patern);
                    _generate = false;
                }
                else
                {
                    Trace.TraceError("You need to setup at least one prefab");
                }
            }
        }

        private void GenerateTrack(Transform container, GameObject[] prefabs, int numberOfElements, Vector3 initialPosition, Vector3 space, PATERN_TYPE drawPatern)
        {
            GameObject trackInstance;
            int index;

            for (int i = 0; i < numberOfElements; i++)
            {
                if (drawPatern == PATERN_TYPE.RANDOM)
                {
                    index = Random.Range(0, prefabs.Length);                   
                }
                else
                {
                    index = i % prefabs.Length;
                }

                trackInstance = (GameObject)Instantiate(prefabs[index]);
                trackInstance.name = container.name + i.ToString();
                trackInstance.transform.parent = container;
                trackInstance.transform.localPosition = new Vector3(initialPosition.x + i * space.x, initialPosition.y + i * space.y, initialPosition.z + i * space.z);
            }
        }

        private void ClearTrack(Transform container)
        {
            Transform[] allTransforms = container.GetComponentsInChildren<Transform>();

            foreach (Transform childObjects in allTransforms)
            {
                if (gameObject.transform.IsChildOf(childObjects.transform) == false)
                    DestroyImmediate(childObjects.gameObject);
            }
						
        }
    }
}