using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matrix = MathNet.Numerics.LinearAlgebra.Matrix<double>;
using Vector = MathNet.Numerics.LinearAlgebra.Vector<double>;




public class PlotPoint : MonoBehaviour
{

		void s() {
			Matrix A = Matrix.Build.DenseOfArray(new double[,] {
				{1,0,0},
				{0,2,0},
				{0,0,3}});

			Vector b = Vector.Build.Dense(new double[] {1, 1, 1});

			Vector x = A.Solve(b);
			Debug.Log("x = A^-1b: " + x);
		}



	public GameObject origin;
    public GameObject dotPrefab;
    public int numberOfDots = 0;
    public Vector3[] points;
    public Vector3 originPosition;


    // Use this for initialization
    void Start()
    {
		s ();
        numberOfDots = 0;
        originPosition = origin.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            Instantiate(dotPrefab, new Vector3(mousePoint.x, mousePoint.y, this.transform.position.z), Quaternion.identity);
            numberOfDots += 1;
            Vector3[] newPoints = new Vector3[numberOfDots];
            int i = 0;
            foreach (Vector3 point in points) { newPoints[i] = point; i += 1; }
            newPoints[numberOfDots - 1] = mousePoint;
            points = newPoints;
            print(numberOfDots);
            print(points);
            points[numberOfDots] = mousePoint;
        }

    }
}
