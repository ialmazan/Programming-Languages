public class Matrix extends Sequence{
	private int rowsize;
	private int colsize;
	
	// constructor
	public Matrix(int rowsize, int colsize){
		this.rowsize = rowsize;
		this.colsize = colsize;
		// making the matrix
		for (int i = 0; i < rowsize * colsize; i++){
				MyInteger integer = new MyInteger();
				this.add(integer, i);
			}
	}
	
	//Set
	public void Set(int row, int col, int value){
		((MyInteger)this.index(row * this.colsize + col)).Set(value);
	}
	
	//Get
	public int Get(int rowsize, int colsize){
		int i = ((MyInteger)this.index(rowsize*this.colsize + colsize)).Get();
		return i;
	}
	
	//Sum
	public Matrix Sum(Matrix mat){
		for (int i = 0; i < mat.rowsize; i++){
			for (int j = 0; j < mat.colsize; j++){
				int sum = this.Get(i, j) + mat.Get(i, j); // add
				this.Set(i, j, sum); // fill new matrix
			}
		}
		return this; //return sum
	}
	
	//Product
	public Matrix Product(Matrix mat){
		if (this.colsize != mat.rowsize){ // check if n*m x m*n and flag is not
			System.out.println("Matrix dimensions incompatible for Product");
			System.exit(1);
		}
			Matrix newMat = new Matrix(this.rowsize, mat.colsize);
			int product = 1;
			int sum = 0;
			for (int i = 0; i < newMat.rowsize; i++){
				for (int j = 0; j < newMat.colsize; j++){
					for (int k = 0; k < this.colsize; k++){
						product = this.Get(i, k) * mat.Get(k, j);
						sum = sum + product;
						product = 0; // get ready for next calculation
					}
					newMat.Set(i, j, sum); //fill new matrix
					sum = 0; // get ready for next calculation
				}
			}
			return newMat;
	}
	
	// Print in same format
	public void Print(){
		for (int i = 0; i < rowsize; i++){
			System.out.print("[ ");
			for (int j = 0; j < colsize; j++){
				System.out.print(Get(i, j));
				System.out.print(" ");
			}
			System.out.println("]");

		}
	}
	
	
}
