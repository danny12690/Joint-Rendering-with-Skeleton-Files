using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Joint 
{
	public string name;
	public int parent;
	public float[] offset;
	public float[] pose;
	public float[] boxMin;
	public float[] boxMax;
	public float[] rotXLimit;
	public float[] rotZLimit;
	public float[] rotYLimit;
	public List<Joint> children;
	public Joint()
	{
		offset = new float[3]{0.0f,0.0f,0.0f};
		pose = new float[3]{0.0f,0.0f,0.0f};
		boxMin = new float[3]{-0.1f,-0.1f,-0.1f};
		boxMax = new float[3]{0.1f,0.1f,0.1f};
		rotXLimit = new float[2]{-1.0f,1.0f};
		rotYLimit = new float[2]{-1.0f,1.0f};
		rotZLimit = new float[2]{-1.0f,1.0f};
	}
	public void setName(string name)
	{
		this.name = name;
	}
	public string getName()
	{
		return this.name;
	}
	public void setParent(int parent)
	{
		this.parent = parent;
	}
	public int getParent()
	{
		return this.parent;
	}
	public void setChildren(List<Joint> children)
	{
		this.children = children;
	}
	public List<Joint> getChildren()
	{
		return this.children;
	}
	public void setOffset(float[] offset)
	{
		this.offset = offset;
	}
	public float[] getOffset()
	{
		return this.offset;
	}
	public void setPose(float[] pose)
	{
		this.pose = pose;
	}
	public float[] getPose()
	{
		return this.pose;
	}
	public void setBoxMin(float[] boxMin)
	{
		this.boxMin = boxMin;
	}
	public float[] getBoxMin()
	{
		return this.boxMin;
	}
	public void setBoxMax(float[] boxMax)
	{
		this.boxMax = boxMax;
	}
	public float[] getBoxMax()
	{
		return this.boxMax;
	}
	public void setRotX(float[] rotXLimit)
	{
		this.rotXLimit = rotXLimit;
	}
	public float[] getRotX()
	{
		return this.rotXLimit;
	}
	public void setRotY(float[] rotYLimit)
	{
		this.rotYLimit = rotYLimit;
	}
	public float[] getRotY()
	{
		return this.rotYLimit;
	}
	public void setRotZ(float[] rotZLimit)
	{
		this.rotZLimit = rotZLimit;
	}
	public float[] getRotZ()
	{
		return this.rotZLimit;
	}
}
