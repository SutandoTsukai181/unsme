using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VertexObject : MonoBehaviour {
	public bool Selected = false;

	void OnMouseOver () {

        RenderFile model = GameObject.Find("MODEL VIEWER").GetComponent<RenderFile>();
        if (model.WindowOpen == false && model.inCommand == false)
		{
			if(model.byteLength == 64 || model.byteLength == 96)
			{
				GameObject.Find("VERTEXDATA").GetComponent<Text>().text = "VERTEX " + this.name + ":\nX = " + transform.position.x + "\nY = " + transform.position.y + "\nZ = " + transform.position.z + "\n" + model.vertexBone[int.Parse(gameObject.name)].x.ToString() + " " + model.vertexBone[int.Parse(gameObject.name)].y.ToString() + " " + model.vertexBone[int.Parse(gameObject.name)].z.ToString() + " " + model.vertexBone[int.Parse(gameObject.name)].w.ToString() + "\n\nWeights:" + "\nX = " + model.vertexWeight[int.Parse(gameObject.name)].x.ToString() + "\nY = " + model.vertexWeight[int.Parse(gameObject.name)].y.ToString() + "\nZ = " + model.vertexWeight[int.Parse(gameObject.name)].z.ToString() + "\nW = " + model.vertexWeight[int.Parse(gameObject.name)].w.ToString();
			}
			else if(model.byteLength == 28)
			{
				GameObject.Find("VERTEXDATA").GetComponent<Text>().text = "VERTEX " + this.name + ":\nX = " + transform.position.x + "\nY = " + transform.position.y + "\nZ = " + transform.position.z;
			}
		}
		if(Input.GetMouseButton(0))
		{
			GameObject.Find("Selection Sphere").transform.position = this.gameObject.transform.position;
		}
	}

	public void SelectObject()
	{
		Selected = true;
		GameObject.Find("MODEL VIEWER").GetComponent<RenderFile>().selectedVertex.Add(this.gameObject);
		this.GetComponent<Renderer>().material.color = Color.red;
	}

	public void UnselectObject()
	{
		Selected = false;
		GameObject.Find("MODEL VIEWER").GetComponent<RenderFile>().selectedVertex.Remove(this.gameObject);
		this.GetComponent<Renderer>().material.color = Color.white;
	}

	void OnMouseExit()
	{
		GameObject.Find("VERTEXDATA").GetComponent<Text>().text = "";
	}
}
