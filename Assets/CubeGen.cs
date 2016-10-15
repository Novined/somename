using UnityEngine;
using System.Collections;

public class CubeGen : MonoBehaviour {

	private System.Random rnd;
	public Object prefab;
	
	// данные предыдущей кривой
	private float KAngle;
	private float KLength;
	private float KPointX;
	private float KPointY;
	
	public float MaxAngle			= (float)System.Math.PI/3;		// максимальный угол отклонения
	public float MinDispertion		= 1;	// минимальное расстояние от центра платформы до вектора
	public float MaxDispertion		= 3;	// максимальное расстояние от центра платформы до вектора
	public float MinLength			= 10;	// минимальная длина участка кривой
	public float MaxLength			= 15;	// максимальная длина участка кривой
	public float PlatphormCount	= 8;	// максимальная длина участка кривой

	// Use this for initialization
	void Start () {
		rnd  = new System.Random();
		//KAngle = (float)rnd.NextDouble()*2*MaxAngle - MaxAngle;
		KAngle = (float)rnd.NextDouble()*2*(float)System.Math.PI;
		KLength = (float)rnd.NextDouble()*(MaxLength - MinLength) + MinLength;
		KPointX = 0;
		KPointY = 0;
		
		AddPlatforms();
		
		Rebuld();
		Rebuld();
		Rebuld();
		Rebuld();
		Rebuld();
	}
	
	void Rebuld()
	{
		// Перевычисляем текущий участок основной кривой
		KPointX += (float)System.Math.Cos(KAngle)*KLength;
		KPointY += (float)System.Math.Sin(KAngle)*KLength;
		
		KAngle += (float)rnd.NextDouble()*2*MaxAngle - MaxAngle;
		KLength = (float)rnd.NextDouble()*(MaxLength - MinLength) + MinLength;
		
		AddPlatforms();
	}
	
	void AddPlatforms() {
		// Добавляем платформы
		for (int i = 0; i < PlatphormCount; i++) {
			float CurDispersion = (float)rnd.NextDouble()*(MaxDispertion - MinDispertion) + MinDispertion;
			float CurLength = i*KLength/PlatphormCount;
			float x = KPointX + CurLength*(float)System.Math.Cos(KAngle) - CurDispersion*(float)System.Math.Sin(KAngle);
			float y = KPointY + CurLength*(float)System.Math.Sin(KAngle) + CurDispersion*(float)System.Math.Cos(KAngle);
			Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
