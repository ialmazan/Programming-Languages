public class MyInteger extends Element {
	private int Int;
	
	//constructor
	public MyInteger(){
		Int = 0;
	}
	
	//get
	public int Get(){
		return Int;
	}
	
	//set
	public void Set(int passedInt){
		this.Int = passedInt;
	}
	
	//Prints the corresponding integer
	public void Print(){
		System.out.print(this.Int);
	}
}
