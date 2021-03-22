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
	class GameObject
	{
		protected GameObject m_Parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();

		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
		

		protected Image m_Image;
		protected Texture2D m_Texture;

		public GameObject(string fileName)
		{
			m_Image = LoadImage(fileName);
			m_Texture = LoadTextureFromImage(m_Image);
		}

		public virtual void Update(float fDeltaTime)
		{

		}

		public void UpdateTransforms()
		{
			if (m_Parent != null)
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			else
				m_GlobalTransform = m_LocalTransform;

			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}

		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());
		}
	}
}
