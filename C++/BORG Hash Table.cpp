/* 
Ivan Almazan
ID# 759511
Prof. Glenn Cuevas                                     Assignment 4
CS 41
*/

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

using namespace std;

class Node // node class
{
public:
	string varName; // variable name
	int scope; // scope level
	int value; // value
	Node *next; // pointer
	Node(string varName = " ", int scope = 0, int value = 0, Node *link = 0) // default node constructor
	{
		this->varName = varName;
		this->scope = scope;
		this->value = value;
		next = link;
	}
};

const int TABLE_SIZE = 17; // hash table size, good prime number for modulo hashing

class HashTable // Hash Table Class
{
private:
	Node **table; // our has tempNode node
public:
	HashTable() // deafult constructor that creates an table of objects with null refrences
	{
		table = new Node*[TABLE_SIZE];
		for (int i = 0; i < TABLE_SIZE; i++)
			table[i] = NULL;
	}
	
	void insert(string varName = " ", int scope = 0, int value = 0, Node *link = 0) // insert method with default values
	{
		int total = 0;
		for(int i = 0, l = 1; i < varName.length(); i++, l++) // calculate first part of hash key
		{
		total += l * int(varName[i]); // adds index value to ordinal number of the letter to total
		}
		int hash = (total % TABLE_SIZE); // total table size to get hash key
		if (table[hash] == NULL) // if it is empty just place new node in there
			table[hash] = new Node(varName, scope, value, link);
		else
		{
			Node *tempNode = table[hash];
			while (tempNode->next != NULL)   // or else create a temp node and traverse the list to get to an empty null pointer and place it there
			tempNode = tempNode->next;
			tempNode->next = new Node(varName, scope, value, link);
		}
	}
	
	void print(string varName, int scope, string operation = " ", int amount = 0) // print method class
	{
		int total = 0;
		for(int i = 0, l = 1; i < varName.length(); i++, l++) // same as insert to get hash key to know where to begin
		{
		total += l * int(varName[i]);
		}
		int hash = (total % TABLE_SIZE); // hash key
		Node *tempNode = table[hash]; // temp node to traverse
		while (tempNode != NULL && tempNode->next != NULL) // to get to the end of the list
			tempNode = tempNode->next;
		if (tempNode == NULL) // if name hash resulted in a value that isn't in the table, it would be empty thus value would be undefined
			cout << varName << " UNDEFINED" << endl;
		else if(tempNode->varName == varName && tempNode->scope <= scope) // else check if the name matches and if it is in scope, if it is print it out
			cout << tempNode->varName << " is " <<  tempNode->value << endl;
		else // the value isn't in scope
			cout << varName << " NOT IN SCOPE " << endl;
	}

	void arithmetic(string varName, int scope, string arithmetic, int amount = 0) // method used to do all the artihmetic and to assign values
	{
		int total = 0;
		for(int i = 0, l = 1; i < varName.length(); i++, l++)
		{
		total += l * int(varName[i]);
		}
		int hash = (total % TABLE_SIZE); // as always get hash key to know where to start
		Node *tempNode = table[hash]; // temp node to traverse
		while (tempNode != NULL && tempNode->next != NULL) // traverse to last node as long as long as hash location isn't empty
			tempNode = tempNode->next;
		if (tempNode == NULL) // if the node is null, the variable wasn't defined using insert fuction
			cout << varName << " UNDEFINED " << endl;
		else
		{
			if(tempNode->varName == varName && tempNode->scope <= scope) // else check if the name matches and if it is in scope, if it is continue and perform operation
			{
				if(arithmetic == "++") // post increment operator
					tempNode->value++;
				else if(arithmetic == "--") // post decrement operator
					tempNode->value--;
				else if(arithmetic == "=") // assign a value
					tempNode->value = amount;
				else if(arithmetic == "*") // multiplication 
					cout<< tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << tempNode->value * amount << endl;
				else if(arithmetic == "+") // addition
					cout<< tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << tempNode->value + amount << endl;
				else if(arithmetic == "-") // subtraction
					cout<< tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << tempNode->value - amount << endl;
				else if(arithmetic == "/") // diision
					cout<< tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << tempNode->value / amount << endl;
				else if(arithmetic == "%") // modulo
					cout<< tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << tempNode->value % amount << endl;
				else if(arithmetic == "^") // exponent
					cout << tempNode->varName << ' ' << arithmetic << ' ' << amount << " is " << pow(double(tempNode->value),amount)  << endl;
			}
			else
				cout << varName << " NOT IN SCOPE " << endl;
		}
	}
};

int main (void)
{
	HashTable borg; // instantiate hastbale
	int level = 0; // scope level to pass to node
	string word; // holds current word from file
	string name; // to temporaraly store stream word
	string operation; // to hold operation being performed to pass to arithmetic
	string temp; // temp holder for when print is called with out an operation if being called
	int num; // valuefor variable
	ifstream stream("C:\\Users\\Ivan Almazan\\desktop\\BORG.txt"); // read from txt file
	while(!stream.eof()) // keep reading while not at the end of the file
	{
		if(!temp.empty()) // to see if temp is holding anything for when print is called with out an operation if being called
			temp = ""; // if it isn't empty set it back to zero so it can be used again
		else
			stream >> word; // or else get next word in file
		if(word == "COM") // comment line, ignore the whole line
			stream.ignore (numeric_limits<streamsize>::max(), '\n' );
		else if(word == "START") // increase scope level
			level++;
		else if(word == "FINISH") // decrease scope level
			level--;
		else if(word == "VAR") // instantiate a new node to go into the hash table
		{
			stream >> word;
			name = word;
			stream >> word;
			stream >> word;
			istringstream stm;
			stm.str(word); // convert string into int to be passed
			stm >> num; 
			borg.insert(name,level,num); // call insert method and pass current values
		}
		else if(word == "PRINT") // print data
		{
			stream >> word;
			name = word;
			stream >> word;
			if (word == "*" || word == "/" || word == "+" || word == "-" || word == "%" || word == "^") // for when we are printing and performing an operation
			{
				operation = word;
				stream >> word;
				istringstream stm;
				stm.str(word);
				stm >> num;
				borg.arithmetic(name,level,operation,num); // call arithmetic function 
			}
			else // when we are only printing
			{
				borg.print(name,level); // call print function
				temp = word; // temp will hold the extra word used to check if we had an operaion to perform
			}
		}
		else // default case where we are simply using pre or post increment or when we are assing a new value to a current variable
		{
			name = word;
			stream >> word;
			if(word == "++" || word == "--") // pre/post
				borg.arithmetic(name, level, word); // call arithmetic and pass operation to perform
			else if( word == "=") // assign a new value to variable
			{
				operation = word;
				stream >> word;
				istringstream stm;
				stm.str(word);
				stm >> num;
				borg.arithmetic(name, level, operation, num); // pass data and new value to arithmetic
			}
			else
				cout << word << endl; // i used to check if something wasn't getting picked
		}
	}
	system("pause"); // pause console output at end of program to see results
	return 0;
}

/*    Program TXT file input

COM HERE IS OUR FIRST BORG PROGRAM
COM WHAT A ROBUST LANGUAGE IT IS
START
   VAR BORAMIR = 25
   VAR LEGOLAS = 101
   PRINT BORAMIR
   BORAMIR ++
   PRINT LEGOLAS
   PRINT GANDALF
   PRINT BORAMIR * 2
   PRINT BORAMIR + 103
   PRINT BORAMIR - 12
   PRINT BORAMIR / 5
   PRINT BORAMIR % 8
   PRINT BORAMIR ^ 3
   COM
   COM NESTED BLOCK
   COM
   START
      VAR GANDALF = 49
      PRINT GANDALF
      PRINT BORAMIR
   FINISH
   PRINT GANDALF
   START
      LEGOLAS = 1000
      PRINT LEGOLAS
   FINISH
   PRINT LEGOLAS
   LEGOLAS --
   PRINT LEGOLAS
   START
      PRINT GANDALF
   FINISH
FINISH
*/

/*   OUTPUT

BORAMIR is 25
LEGOLAS is 101
GANDALF UNDEFINED
BORAMIR * 2 is 52
BORAMIR + 103 is 129
BORAMIR - 12 is 14
BORAMIR / 5 is 5
BORAMIR % 8 is 2
BORAMIR ^ 3 is 17576
GANDALF is 49
BORAMIR is 26
GANDALF NOT IN SCOPE
LEGOLAS is 1000
LEGOLAS is 1000
LEGOLAS is 999
GANDALF is 49
Press any key to continue . . .
*/