using UnityEngine;
using System.Collections;

namespace Miup.Vehicle.App.Utils
{
    public class Billboard : MonoBehaviour
    {

        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}