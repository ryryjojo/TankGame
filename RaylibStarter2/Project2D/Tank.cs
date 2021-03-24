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
	class Tank : GameObject
	{
		private Turret m_Turret = null;

		private Vector2 m_v2Velocity;

		public Tank(string fileName) : base(fileName)
		{
			m_Turret = new Turret("../Images/Turret(1).png");
			m_Turret.SetParent(this);

			m_LocalTransform.m7 = 250;
			m_LocalTransform.m8 = 250;

			m_v2Velocity.x = 0;
			m_v2Velocity.y = 0;
		}

		public override void Update(float fDeltaTime)
		{
			float fRotation = 0.0f;

			if(IsKeyDown(KeyboardKey.KEY_W))
			{
				m_v2Velocity.y -= m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_S))
			{
				m_v2Velocity.y += m_fSpeed * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_A))
			{
				fRotation -= 2.0f * fDeltaTime;
			}
			if (IsKeyDown(KeyboardKey.KEY_D))
			{
				fRotation += 2.0f * fDeltaTime;
			}

			Matrix3 translation = new Matrix3(true);
			translation.m8 = m_v2Velocity.y * fDeltaTime;
			m_LocalTransform = m_LocalTransform * translation;

			Matrix3 rotation = new Matrix3(true);
			rotation.SetRotateZ(fRotation);
			m_LocalTransform = m_LocalTransform * rotation;

			base.Update(fDeltaTime);
		}

		public override void OnCollision(GameObject otherObj)
		{
			m_LocalTransform.m7 = m_v2PrevPosition.x;
			m_LocalTransform.m8 = m_v2PrevPosition.y;

			//Vector2 reflection = -2.0f * m_v2Velocity.Dot(Vector2Normalize) * v2Normal + m_v2Velocity;
			Vector2 v2Normal = otherObj.GetPosition() - GetPosition();
			v2Normal.Normalise();

			Vector2 reflection = -2.0f * m_v2Velocity.Dot(v2Normal) * v2Normal + m_v2Velocity;

			m_v2Velocity = reflection;
		}
	}
}
//m_LocalTransform.m8 -= 100.0f * fDeltaTime;