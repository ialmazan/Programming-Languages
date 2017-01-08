public class Sequence extends Element{
	private Element element;
	private Sequence nextNode;
	
	//constructor
	public Sequence(){
		element = null;
		nextNode = null;
	}
	
	//get current element
	public Element getElement(){
		return this.element;
	}
	
	//set current element
	public void setElement(Element elm){
		this.element = elm;
	}
	
	//get nextNode
	public Sequence getNextNode(){
		return this.nextNode;
	}
	
	//set nextNode
	public void setNextNode(Sequence node){
		this.nextNode = node;
	}
	
	
	//Define method first to return the first element of the sequence
	public Element first(){
		return this.getElement();
	}
	
	//Define a method rest that returns the rest of the elements of the seqence
	public Sequence rest(){
		return this.getNextNode();
	}
	
	//Define a method length to return the number of elements in a Sequence object
	public int length(){
		int length = 0;
		Sequence tempNode = this; //create tempprary sequence to traverse length
		if (this.element == null){ // return 0 if sequence is empty
			return 0;
		}

		while (tempNode != null){ // while not empty loop adding to length
			length++;
			tempNode = tempNode.nextNode;
		}
		return length;
	}
	
	//Define a method add to add an element at a specified position
	public void add(Element elm, int pos){
		if (pos < 0 || pos > length()){ // check if in range flag error and exit
			System.err.println("pos out of bound!"); 
			System.exit(1);
		}
		
		// if element is empty, set the first element to elm
		if (this.element == null){ 
			this.setElement(elm);
			
		// if we are at the end, append the elm to the right 	
		}else if(pos == length()){ 
			Sequence newNode = new Sequence(); // create the newNode
			newNode.setElement(elm); // set to elm
			Sequence currentNode = this;
			for (int i = 1; i < pos; i++){
				currentNode = currentNode.nextNode;
			}
			currentNode.nextNode = newNode;// once we found the end, insert the newNode to the right
		}
		
		// if position is in range
		else{
			Sequence newNode = new Sequence(); // create the newNode
			newNode.setElement(elm); // set to elm
			Sequence currentNode = this;
			for (int i = 1; i < pos; i++){ // in the middle insert
				currentNode = currentNode.nextNode;
			}
			newNode.nextNode = currentNode.nextNode;
			currentNode.nextNode = newNode;
			// at pos 0 insert we do a swap
			if (pos == 0){
				Sequence temp = new Sequence();
				temp.element = currentNode.element;
				currentNode.element = currentNode.nextNode.element;
				currentNode.nextNode.element = temp.element;
			}
		}

	}
		
	
	// Define a delete method to remove an element at a specified position
	public void delete(int pos){
		// out of bounds check
		if (pos < 0 || pos >= length()){
			System.err.println("pos out of bound!"); 
			System.exit(1);
		}
		// at the begining
		else if (pos == 0){ 
			Sequence currentNode = this;
			Sequence tempNode = currentNode.nextNode; // store second
			currentNode.nextNode = currentNode.nextNode.nextNode; // point first to third
			currentNode.element = tempNode.element; // first = second
		
		//not at the begining
		}else{
			Sequence currentNode = this;
			for (int i = 1; i < pos; i++){ // get into position to change pointers
				currentNode = currentNode.nextNode;
			}
			currentNode.nextNode = currentNode.nextNode.nextNode; // point current node to the node 1 over the next
			
		}
		
	}
	
	// Now print with new format of [ [ 1 ] [ 2 ] '3' 'c' [ 1 3 ['4' '5'] ] ] to match output
	public void Print(){
		System.out.print("[ ");
		Sequence temp = this;
		while (temp != null){
			temp.getElement().Print();
			System.out.print(" ");
			temp = temp.nextNode;
		}
		System.out.print("]");
	}
	
	
	// index to access the element at a particular position
	public Element index(int pos){
		if (pos < 0 || pos >= this.length()){// out of bounds checking and flag
			System.err.println("Position is out of boundary!");
			System.exit(1);		
		}
		Sequence currentNode = this;
		for (int i = 0; i < pos; i++){ // find the index given
			currentNode = currentNode.nextNode;
		}
		return currentNode.element; // return once found
	}
	
	// flatten ([1 2 [1 3 4] ['s' a b] ]) = [1 2 1 3 4 's' a b]
	public Sequence flatten(){
		Sequence newSeq = new Sequence();
		Sequence currentNode = this;
		int counter = 0; // to keep track of position
		while(currentNode != null){ // while not empty
			if (currentNode.element instanceof Sequence){ // check if nested sequence
				Sequence tempNode = ((Sequence)currentNode.element).flatten();
				while (tempNode != null){ // check if nested sequence if empty
					newSeq.add(tempNode.element, counter); // add elements and update position
					tempNode = tempNode.nextNode;
					counter++;
				}
			}else if (currentNode.element instanceof MyChar || currentNode.element instanceof MyInteger){ // if not a nested sequence, just add it
				newSeq.add(currentNode.element, counter); //add the element
				counter++; // update position
			}
			currentNode = currentNode.nextNode; // move to next node and repeat
		}
		return newSeq; // return flattened sequence
	}
	
	// deep copy
	public Sequence copy(){
		
		Sequence newSeq = new Sequence();
		Sequence currentNode = this;
		int counter = 0; // keep track of position
		while(currentNode != null){; 
			if (currentNode.element instanceof Sequence){ // check if nested sequence
				newSeq.add(((Sequence)currentNode.element).copy(), counter); // loop copy and add until null
			}else if(currentNode.element instanceof MyChar){
				MyChar myChar = new MyChar(); // create new char 
				myChar.Set(((MyChar)currentNode.element).Get()); // set it
				newSeq.add(myChar, counter); // add it
			}else if(currentNode.element instanceof MyInteger){
				MyInteger myInteger = new MyInteger(); // create new int 
				myInteger.Set(((MyInteger)currentNode.element).Get()); // set it
				newSeq.add(myInteger, counter); //add it
			}
			counter++; // update position
			currentNode = currentNode.nextNode; // move to next node and repeat
		}
		return newSeq; // return copy

	}
		
	// begin returns a SequenceIterator object that points to the first element of the sequence
	public SequenceIterator begin(){
		SequenceIterator seqIt = new SequenceIterator();
		seqIt.setcurrent(this);
		return seqIt;
	}
	
	// returns a SequenceIterator object that points to null
	public SequenceIterator end(){
		SequenceIterator seqIt = new SequenceIterator();
		Sequence current = this;
		while(current.nextNode != null){ // traverse to the end and point to next which is null
			current = current.nextNode;
		}
		seqIt.setcurrent(current.nextNode);
		return seqIt;
	}
}
	
