using Parkour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parkour
{
    public class MutantAnimationReceiver : MonoBehaviour
    {
        // Start is called before the first frame update

        public MutantControllerTest MutantController;

        void StartCheckingTarget()
        {
            MutantController.StartCheckingTarget();
        }

        void EndCheckingTarget()
        {
            MutantController.EndCheckingTarget();
        }

    }

}