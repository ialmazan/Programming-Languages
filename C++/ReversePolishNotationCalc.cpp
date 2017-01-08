//Ivan Almazan ID#759511
#include <string>
#include <sstream>
#include <iostream>

using namespace std;

class StackNode 
{
public:
    double info;			// data
    StackNode *next;	// Link
    StackNode(double data, StackNode *ptr = 0) 
	{
        info = data; 
		next = ptr;
    }
};

class Stack 
{
public:
    Stack();
    ~Stack();
	void push(double data);
    double  pop();
	void add();
	void subtract();
	void multiply();
	void divide();
	void printAll() const; 

private:
    StackNode *head;  // node that we will be used to quickly access the top
};

Stack::Stack() // constructor sets head to zero
{
	head = 0;
}

Stack::~Stack()
{
	for (StackNode *p; head != 0; ) // deletes nodes while stack isn't empty
	{
		p = head->next;	// set our temporary pointer to the next element
		delete head;	// delete the head
		head = p;		// sets the new head
	}
}

void Stack::push(double data)   	    // Add the new node to the front of the list at the head
{
		head = new StackNode(data,head);  // The node constructor handles the linking of the two nodes together
}

double Stack::pop() // delete the head and return its info;
{
	double data = head->info;	// save data so it isn't lost when deleted
	StackNode *tmp = head;	    // create a pointer to head
	head = head->next;	       // set the new head
	delete tmp;				   // deletes old head
	return data;			   // return the data from the head that was deleted
} 

void Stack::add()
{
	if(head == NULL || head->next == NULL) //checks if there are two operands to perform addition, same for 
		cout<<"Error: Too Many Operators Invalid ";
	else
	{
		push(pop() + pop());
	}
}


void Stack::subtract()
{
	if(head == NULL || head->next == NULL)
		cout<<"Error: Too Many Operators Invalid ";
	else
	{
		double num;
		num = pop();
		push(pop() - num);
	}
}

void Stack::multiply()
{
	if(head == NULL || head->next == NULL)
		cout<<"Error: Too Many Operators Invalid ";
	else
	{
		push(pop() * pop());
	}
}

void Stack::divide()
{
	if(head == NULL || head->next == NULL)
		cout<<"Error: Too Many Operators Invalid ";
	else
	{
		double num;
		num = pop();
		if(num != 0.0) // checks for division by zero error
			push(pop() / num);
		else
			cout << "Error: Division By Zero, Invalid ";
	}
}

void Stack::printAll() const // Print the result
{
	if(head != NULL && head->next == NULL) // checks to see if there is only one number left in the stack
		cout << "Result is :" << head->info << endl << endl;
	else if(head != NULL && head->next != NULL)// checks to see if too many operands were input
		cout << "Error: Too Many Operands" << endl << endl;
	else
		cout << " " << endl << endl;
}

int main (void)
{
	Stack *theStack = new Stack(); // constucts a stack called thestack
	string expression = "";
	while(expression != "0") // user will enter expression until 0 is entered
	{
		cout << "Enter an Expression ";
		getline (cin,expression);
		stringstream stream;
		string token;
		stream << expression;
		while(!stream.eof()) // while the stream isn't at the end of the file it will parse and determine what operation to do
		{
			stream >> token; 
			if(token == "+")
				theStack->add();
			else if(token == "-")
				theStack->subtract();
			else if(token == "*")
				theStack->multiply();
			else if(token == "/")
				theStack->divide();
			else
			{
				istringstream stm; // coverts the string token into a double and pushes it onto stack
				stm.str(token);
				double num;
				stm >> num;
				theStack->push(num);
			}
		}
		theStack->printAll();
		theStack->~Stack(); // clean stack for re-use if needed
	}
	return 0;
}