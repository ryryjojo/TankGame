using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Wall : GameObject
	{
		public Wall(string fileName) : base(fileName)
		{
			m_LocalTransform.m7 = 560;
			m_LocalTransform.m8 = 250;

			m_Min.x = -74;
			m_Min.y = -74;

			m_Max.x = 74;
			m_Max.y = 74;
		}

		public override void Update(float fDeltaTime)
		{
			base.Update(fDeltaTime);
		}
	}
}
