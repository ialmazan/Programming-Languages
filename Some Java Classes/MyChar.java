public class MyChar extends Element{
	private char Char;
	
	//constructor
	public MyChar(){
		Char = '0';
	}
	
	//get
	public char Get(){ 
		return Char;
	}
	
	//set
	public void Set(char passedChar){
		this.Char = passedChar;
	}
	
	//Prints the corresponding char in quotes
	public void Print(){
		System.out.print("'"+this.Char+"'");
	}
}
