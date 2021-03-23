using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{
	class Turret : GameObject
	{
		public Turret(string fileName) : base(fileName)
		{
			m_LocalTransform.m7 = 0;
			m_LocalTransform.m8 = 50;
		}

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;

			
			if (IsKeyDown(KeyboardKey.KEY_Q))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_E))
			{
				fRotation += 2.0f * fDeltaTime;
			}

			Matrix3 rotation = new Matrix3(true);
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}
	}
}
