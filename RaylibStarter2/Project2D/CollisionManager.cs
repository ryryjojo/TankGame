using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathLibrary;

namespace Project2D
{
	static class CollisionManager
	{
		private static List<GameObject> m_ObjectList = new List<GameObject>();

		public static void AddObject(GameObject obj)
		{
			m_ObjectList.Add(obj);
		}

		//check every object with collision if they are colliding
		public static void CheckCollision()
		{
			foreach(GameObject obj1 in m_ObjectList)
			{
				foreach(GameObject obj2 in m_ObjectList)
				{
					if (obj1 == obj2)
						continue;

					if (obj1.m_collision == false || obj2.m_collision == false)
						continue;

					Vector2 obj1Min = obj1.GetMin() + obj1.GetPosition();
					Vector2 obj1Max = obj1.GetMax() + obj1.GetPosition();
					Vector2 obj2Min = obj2.GetMin() + obj2.GetPosition();
					Vector2 obj2Max = obj2.GetMax() + obj2.GetPosition();

					if ((obj2Max.x >= obj1Min.x) && (obj2Max.y >= obj1Min.y) && (obj2Min.x <= obj1Max.x) && (obj2Min.y <= obj1Max.y))
					{
						obj1.OnCollision(obj2);
					}
				}
			}
		}
	}
}
