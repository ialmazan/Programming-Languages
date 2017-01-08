#include <iostream>
#include <fstream>

//Ivan Almazan
//912383996

using namespace std;

int main (int argc, char *argv[]) 
{
	int dim = 0, matrixSize = 0;
	int *matA, *matB, *matAB;

	ifstream file1(argv[1]);	
	file1 >> dim;
	matrixSize = ((1 + dim)*dim)/2;
	matA = new int[matrixSize];
	for(int i = 0; i <= matrixSize;i++)
		file1 >> matA[i];
	file1.close();
	
	ifstream file2(argv[2]);	
	file2 >> dim;
	matB = new int[matrixSize];
	for(int i = 0; i <= matrixSize;i++)
		file2 >> matB[i];
	file2.close();
	
	matAB = new int[matrixSize];
	for(int i = 0; i < matrixSize; i++)
        	matAB[i] = 0;

	for(int i = 0; i < dim; i++)
	{
    		for(int j = i; j < dim; j++)
		{
    			for(int k = i; k <= j; k++)
			{
			matAB[i * dim + j - (i*(i + 1)/2)] += matA[i * dim + k - (i*(i + 1)/2)] * matB[k * dim + j - (k*(k + 1)/2)];
			}
		}
	}
	
	for(int i = 0; i < matrixSize; i++)
		cout << matAB[i] << " ";
	cout << endl;
	
	delete[] matA;
    	delete[] matB;
    	delete[] matAB;
	
	return 0;
}


