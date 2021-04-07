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
		//initialise variables
		protected GameObject m_Parent = null;
		protected List<GameObject> m_Children = new List<GameObject>();

		protected Matrix3 m_LocalTransform;
		protected Matrix3 m_GlobalTransform;
	
		protected Image m_Image;
		protected Texture2D m_Texture;

		public Vector2 m_Min;
		public Vector2 m_Max;

		public bool m_collision = true;

		protected Vector2 m_v2PrevPosition;
		protected float m_fSpeed = 100.0f;

		//gameobject constructor
		public GameObject(string fileName)
		{
			m_LocalTransform = new Matrix3(true);
			m_GlobalTransform = new Matrix3(true);
			m_Image = LoadImage(fileName);
			m_Texture = LoadTextureFromImage(m_Image);

			CollisionManager.AddObject(this);
		}

		//parent/children code
		public void SetParent(GameObject parent)
		{
			if (m_Parent != null)
				m_Parent.m_Children.Remove(this);

			m_Parent = parent;

			if (m_Parent != null)
				m_Parent.m_Children.Add(this);
		}

		//updates children when parents are updated
		public virtual void Update(float fDeltaTime)
		{
			foreach (GameObject child in m_Children)
			{
				child.Update(fDeltaTime);
			}	
		}

		//updates childrens transforms when parents transforms are updated
		public void UpdateTransforms()
		{
			if (m_Parent != null)
				m_v2PrevPosition = GetPosition() + m_Parent.GetPosition();
			else
				m_v2PrevPosition = GetPosition();

			if (m_Parent != null)
				m_GlobalTransform = m_Parent.m_GlobalTransform * m_LocalTransform;
			else
				m_GlobalTransform = m_LocalTransform;

			foreach(GameObject child in m_Children)
			{
				child.UpdateTransforms();
			}
		}

		//draw objects
		public void Draw()
		{
			Renderer.DrawTexture(m_Texture, m_GlobalTransform, RLColor.WHITE.ToColor());

			foreach (GameObject child in m_Children)
			{
				child.Draw();
			}
		}

		//constructor (to override)
		public virtual void OnCollision(GameObject otherObj)
		{
		}

		//get objects position
		public Vector2 GetPosition()
		{
			return new Vector2(m_GlobalTransform.m7, m_GlobalTransform.m8);
		}

		//get objects bounding box
		public Vector2 GetMin()
		{
			return m_Min;
		}

		public Vector2 GetMax()
		{
			return m_Max;
		}
	}
}
