/*
 * Computer Animation and Gaming Assignment 2.
 * Author : Dhananjay Singh
 * UTD Id : 2021250625 
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

public class FileTokenizer : MonoBehaviour 
{
	public int status=0;
	Joint b1=new Joint();
	List<Joint> c=new List<Joint>(1){};
	int childs=0;
	int over=0;
	int flag;
	Stack<Joint> ob = new Stack<Joint> ();
	Stack st = new Stack ();
	int i=0;
	int count=0;
	int items=0;
	String[] s1,s2;
	String str="";
	StreamReader reader=null;
	String file1="test4unity.skel";
	String file2="dragon4unity.skel";

	public void renderChild(Joint k)
	{
		foreach (Joint l in k.children) {
			GameObject g = new GameObject ();
			MeshFilter filter = g.AddComponent< MeshFilter > ();
			g.AddComponent<MeshRenderer> ();
			Mesh mesh = filter.mesh;
			mesh.Clear ();
			String rootName = k.getName ();
			g.name = l.getName ();
			GameObject parents = GameObject.Find(k.name);
				g.transform.parent = parents.transform;
			if (l.pose [0] <= l.rotXLimit [0])
				l.pose [0] = l.rotXLimit [0];
			if (l.pose [0] >= l.rotXLimit [1])
				l.pose [0] = l.rotXLimit [1];
			if (l.pose [1] <= l.rotXLimit [0])
				l.pose [1] = l.rotYLimit [0];
			if (l.pose [1] >= l.rotYLimit [1])
				l.pose [1] = l.rotYLimit [1];
			if (l.pose [2] <= l.rotZLimit [0])
				l.pose [2] = l.rotZLimit [0];
			if (l.pose [2] >= l.rotZLimit [1])
				l.pose [2] = l.rotZLimit [1];
			Vector3 p0 = new Vector3 (l.boxMin [0], l.boxMin [1], l.boxMin [2]);
			Vector3 p1 = new Vector3 (l.boxMax [0], l.boxMin [1], l.boxMin [2]);
			Vector3 p2 = new Vector3 (l.boxMax [0], l.boxMin [1], l.boxMax [2]);
			Vector3 p3 = new Vector3 (l.boxMin [0], l.boxMin [1], l.boxMax [2]);	

			Vector3 p4 = new Vector3 (l.boxMin [0], l.boxMax [1], l.boxMin [2]);
			Vector3 p5 = new Vector3 (l.boxMax [0], l.boxMax [1], l.boxMin [2]);
			Vector3 p6 = new Vector3 (l.boxMax [0], l.boxMax [1], l.boxMax [2]);
			Vector3 p7 = new Vector3 (l.boxMin [0], l.boxMax [1], l.boxMax [2]);

			Vector3[] vertices = new Vector3[] {
				// Bottom
				p0, p1, p2, p3,

				// Left
				p7, p4, p0, p3,

				// Front
				p4, p5, p1, p0,

				// Back
				p6, p7, p3, p2,

				// Right
				p5, p6, p2, p1,

				// Top
				p7, p6, p5, p4
			};
			int[] triangles = new int[] {
				// Bottom
				3, 1, 0,
				3, 2, 1,			

				// Left
				3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
				3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,

				// Front
				3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
				3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,

				// Back
				3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
				3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,

				// Right
				3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
				3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,

				// Top
				3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
				3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,

			};
			mesh.vertices = vertices;
			mesh.RecalculateNormals ();
			mesh.triangles = triangles;
			mesh.RecalculateBounds ();
			mesh.Optimize ();
			g.transform.localPosition = new Vector3 (l.offset [0], l.offset [1], l.offset [2]);
			g.transform.localRotation = Quaternion.AngleAxis (l.pose[2]*Mathf.Rad2Deg,Vector3.forward) * Quaternion.AngleAxis (l.pose[1]*Mathf.Rad2Deg,Vector3.up) * Quaternion.AngleAxis (l.pose[0]*Mathf.Rad2Deg,Vector3.right);
			renderChild (l);
		}
	}
		
	public void render()
	{
		foreach(Joint j in c)
		{
		GameObject g = new GameObject ();
		MeshFilter filter = g.AddComponent< MeshFilter >();
		g.AddComponent<MeshRenderer> ();
		Mesh mesh = filter.mesh;
		mesh.Clear();
		String rootName = j.getName ();
		g.name = j.getName ();

		Vector3 p0 = new Vector3(j.boxMin[0],j.boxMin[1],j.boxMin[2]);
		Vector3 p1 = new Vector3(j.boxMax[0],j.boxMin[1],j.boxMin[2]);
		Vector3 p2 = new Vector3(j.boxMax[0],j.boxMin[1],j.boxMax[2]);
		Vector3 p3 = new Vector3(j.boxMin[0],j.boxMin[1],j.boxMax[2]);	

		Vector3 p4 = new Vector3(j.boxMin[0],j.boxMax[1],j.boxMin[2]);
		Vector3 p5 = new Vector3(j.boxMax[0],j.boxMax[1],j.boxMin[2]);
		Vector3 p6 = new Vector3(j.boxMax[0],j.boxMax[1],j.boxMax[2]);
		Vector3 p7 = new Vector3(j.boxMin[0],j.boxMax[1],j.boxMax[2]);

		Vector3[] vertices = new Vector3[]
		{
			// Bottom
			p0, p1, p2, p3,

			// Left
			p7, p4, p0, p3,

			// Front
			p4, p5, p1, p0,

			// Back
			p6, p7, p3, p2,

			// Right
			p5, p6, p2, p1,

			// Top
			p7, p6, p5, p4
		};
		int[] triangles = new int[]
		{
			// Bottom
			3, 1, 0,
			3, 2, 1,			

			// Left
			3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
			3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,

			// Front
			3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
			3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,

			// Back
			3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
			3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,

			// Right
			3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
			3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,

			// Top
			3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
			3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,

		};
		mesh.vertices = vertices;
		mesh.RecalculateNormals ();
		mesh.triangles = triangles;
		mesh.RecalculateBounds ();
		mesh.Optimize ();
		g.transform.localPosition = new Vector3 (j.offset [0], j.offset [1], j.offset [2]);
		g.transform.localRotation = Quaternion.AngleAxis (j.pose[2]*Mathf.Rad2Deg,Vector3.forward) * Quaternion.AngleAxis (j.pose[1]*Mathf.Rad2Deg,Vector3.up) * Quaternion.AngleAxis (j.pose[0]*Mathf.Rad2Deg,Vector3.right);
		renderChild (j);
	}
	}

	public void bodyMaker(int status)
	{
		FileStream f1;
		if(status==0)
		f1=new FileStream(Application.dataPath+"/Resources/test4unity.skel",FileMode.Open); 
		else
		f1=new FileStream(Application.dataPath+"/Resources/dragon4unity.skel",FileMode.Open); 
		StreamReader sr = new StreamReader (f1);
		while((str=sr.ReadLine())!=null)
		{

			if (str.Contains ("{"))
			{

				if (count == 0) {
					i++;
					b1 = new Joint ();
					b1.children= new List<Joint>{ };
					over = 0;
					count++;
					s1 = str.Split (' ');
					b1.name = s1 [1];
					//ob.Push (b1);

				} 
				else {
					if (i == 1) {
						c.Add (b1);
						i++;
					}
					ob.Push (b1);						
					b1 = new Joint ();
					b1.children = new List<Joint>{ };
					over = 0;
					count++;
					s1 = str.Split (' ');
					b1.name = s1 [1];

				}
			}
			else if (str.Contains ("offset")) {
				s1 = str.Split (' ');
				b1.offset = new float[3];
				b1.offset [0] = float.Parse (s1 [1]);
				b1.offset [1] = float.Parse (s1 [2]);
				b1.offset [2] = float.Parse (s1 [3]);
			} else if (str.Contains ("boxmin")) {
				s1 = str.Split (' ');
				b1.boxMin = new float[3];
				b1.boxMin [0] = float.Parse (s1 [1]);
				b1.boxMin [1] = float.Parse (s1 [2]);
				b1.boxMin [2] = float.Parse (s1 [3]);
			} else if (str.Contains ("boxmax")) {
				s1 = str.Split (' ');
				b1.boxMax = new float[3];
				b1.boxMax [0] = float.Parse (s1 [1]);
				b1.boxMax [1] = float.Parse (s1 [2]);
				b1.boxMax [2] = float.Parse (s1 [3]);
			} else if (str.Contains ("rotxlimit")) {
				s1 = str.Split (' ');
				b1.rotXLimit = new float[2];
				b1.rotXLimit [0] = float.Parse (s1 [1]);
				b1.rotXLimit [1] = float.Parse (s1 [2]);
			} else if (str.Contains ("rotylimit")) {
				s1 = str.Split (' ');
				b1.rotYLimit = new float[2];
				b1.rotYLimit [0] = float.Parse (s1 [1]);
				b1.rotYLimit [1] = float.Parse (s1 [2]);
			} else if (str.Contains ("rotzlimit")) {
				s1 = str.Split (' ');
				b1.rotZLimit = new float[2];
				b1.rotZLimit [0] = float.Parse (s1 [1]);
				b1.rotZLimit [1] = float.Parse (s1 [2]);
			} else if (str.Contains ("pose")) {
				s1 = str.Split (' ');
				b1.pose = new float[3];
				b1.pose [0] = float.Parse (s1 [1]);
				b1.pose [1] = float.Parse (s1 [2]);
				b1.pose[2]=float.Parse(s1[3]);
			} else if (str.Contains ("}")) {
				over = 1;
				--count;

				Joint b2=new Joint();
				if(count!=0)
					b2 = (Joint)ob.Pop();
				if (count != 0)
					b2.children.Add (b1);
				b1 = b2;
				flag=1;
			}				
			else {

			}
		}
		render ();
	}
	void Start ()
	{
		bodyMaker (status);
	}
		
	void Update () 
	{
	}
}
