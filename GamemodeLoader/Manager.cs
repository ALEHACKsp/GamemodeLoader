using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GamemodeLoader
{
    public class Manager : MonoBehaviour
    {
        public GameObject objectspawn1;
		public GameObject manger;
	
		void Start()
		{
			manger = GameObject.Find("Manager");
			DontDestroyOnLoad(this.manger);

			objectspawn1 = new GameObject("Testobject");
			DontDestroyOnLoad(objectspawn1);

            // Main
			objectspawn1.AddComponent<Environment>();
        }
    }
}
