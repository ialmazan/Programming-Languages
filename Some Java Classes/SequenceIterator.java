public class SequenceIterator {
	private Sequence current;
	
	//constructor 
	public SequenceIterator(){
		current = null;
	}
	
	//get current
	public Sequence getcurrent (){
		return this.current;
	}
	
	//set current
	public void setcurrent (Sequence current){
		this.current = current;
	}
	
	//point to nextNode
	public SequenceIterator advance(){

		this.setcurrent(current.getNextNode());
		return this; 
	}

	//get object that currently pointing to
	public Element get(){
		return current.getElement();
	}
	
	// check if same element
	public boolean equal(SequenceIterator other){
		return this.current == other.current;

	}
	
}
