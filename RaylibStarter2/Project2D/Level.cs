using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Level : GameObject
	{
		private Tank m_Tank = null;
		private Wall m_Wall = null;

		//create the level
		public Level() : base("")
		{
			//create player in level as child
			m_Tank = new Tank("../Images/Tank Body (1).png");
			m_Tank.SetParent(this);

			//create wall in level as child
			m_Wall = new Wall("../Images/aie-logo-dark.jpg");
			m_Wall.SetParent(this);

			m_collision = false;
		}
	}
}
