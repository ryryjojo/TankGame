﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
	class Level : GameObject
	{
		private Tank m_Tank = null;

		public Level() : base("")
		{
			m_Tank = new Tank("../Images/Tank Body(1).png");
			m_Tank.SetParent(this);
			
		}
	}
}
