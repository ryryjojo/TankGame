using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	static class CollisionManager
	{
		private static List<GameObject> m_ObjectList = new List<GameObject>();

		public static void AddObject(GameObject obj)
		{
			m_ObjectList.Add(obj);
		}

		public static void CheckCollision()
		{
			foreach(GameObject obj1 in m_ObjectList)
			{
				foreach(GameObject obj2 in m_ObjectList)
				{
					if (obj1 == obj2)
						continue;
				}
			}

			//Vector2 object1Min;
			//Vector2 object1Max;

			//Vector2 object2Min;
			//Vector2 object2Max;

			//if (object1Max.x > object2Min.x && object2Max < object1Min &&
		}
	}
}
