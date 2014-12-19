﻿/* Pixelator
 * from david_is_neato
 * reddit unity3D forum
 * http://www.reddit.com/r/Unity3D/comments/20arg7/i_made_a_script_to_make_a_unity_camera_render/
*/

using UnityEngine;
using System.Collections;


//Attach this to a camera
public class Pixelator : MonoBehaviour {
	
	//how chunky to make the screen
	public int pixelSize = 4;
	public FilterMode filterMode = FilterMode.Point;
	public Camera[] otherCameras;
	private Material mat;
	Texture2D tex;
	
	void Start () {
		camera.pixelRect = new Rect(0,0,Screen.width/pixelSize,Screen.height/pixelSize);
		for (int i = 0; i < otherCameras.Length; i++)
			otherCameras[i].pixelRect = new Rect(0,0,Screen.width/pixelSize,Screen.height/pixelSize);
	}
	
	void OnGUI()
	{
		if (Event.current.type == EventType.Repaint)
			Graphics.DrawTexture(new Rect(0,0,Screen.width, Screen.height), tex);
	}
	
	
	void OnPostRender()
	{
		if(!mat) {
			mat = new Material( "Shader \"Hidden/SetAlpha\" {" +
			                   "SubShader {" +
			                   "	Pass {" +
			                   "		ZTest Always Cull Off ZWrite Off" +
			                   "		ColorMask A" +
			                   "		Color (1,1,1,1)" +
			                   "	}" +
			                   "}" +
			                   "}"
			                   );
		}
		// Draw a quad over the whole screen with the above shader
		GL.PushMatrix ();
		GL.LoadOrtho ();
		for (var i = 0; i < mat.passCount; ++i) {
			mat.SetPass (i);
			GL.Begin( GL.QUADS );
			GL.Vertex3( 0, 0, 0.1f );
			GL.Vertex3( 1, 0, 0.1f );
			GL.Vertex3( 1, 1, 0.1f );
			GL.Vertex3( 0, 1, 0.1f );
			GL.End();
		}
		GL.PopMatrix ();	
		
		
		DestroyImmediate(tex);
		
		tex = new Texture2D(Mathf.FloorToInt(camera.pixelWidth), Mathf.FloorToInt(camera.pixelHeight));
		tex.filterMode = filterMode;
		tex.ReadPixels(new Rect(0, 0, camera.pixelWidth, camera.pixelHeight), 0, 0);
		tex.Apply();
	}
	
}