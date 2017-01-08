//Ivan Almazan ID#759511
#include <iostream>
#include <string>
#include <sstream>
#include <fstream>

using namespace std;

class Node // node class
{
public:
	string name;  //name
    int info;				// weight
    Node *nameNext, *weightNext;	// one link for name and one for weight
	
	Node(string n = " ", int data = 0, Node *nptr = 0, Node *wptr = 0) // default constructor
	{
		this->name = n;
        this->info = data; 
		this->nameNext = nptr;
		this->weightNext = wptr;
    }
};

class List //list class
{
public:
	Node *nameFront, *weightFront, *prev; // quick acces nodes, prev keeps track of the prev node when getting into place
	                                      // instead of having more links in the node class to keep track of last

    List() 
	{
      prev = nameFront = weightFront = 0; // default constructor
    }

    void insert(string n = " ", int data = 0) // insert method that inserts nodes in sorted order for both weight and name
	{
		Node *newNode = new Node(n,data);  // new node to be inserted
		Node *temp;
		if (nameFront == 0)									// if list is empty, set quic access nodes equal to new node
		{						
			prev = nameFront = weightFront = newNode;
			return;
		}

		temp = nameFront;                                // set temp to namefront to start sorting by name
		while (temp->nameNext != 0 && temp->name <= n)   // traverse list to get into location and keep track of prev
		{
			prev = temp;
			temp = temp->nameNext;
		}
		
		if (nameFront->nameNext == 0 && weightFront->weightNext == 0)								// adding to list with one node
		{
			if (n < temp->name)						// stick before head
			{
				newNode->nameNext = nameFront;
				nameFront = newNode;
			}
			else										// stick after head
			{
				nameFront->nameNext = newNode;
			}
		}
		else if (temp == nameFront)							// when this happens the the data in the head is greater that our newnode so we need to add it infront
		{
			newNode->nameNext = nameFront;
			prev = newNode;
			nameFront = newNode;                             // set headfront to new node
		}
		else											// or else we just add the new node to the middle to the middle
		{
			newNode->nameNext = temp;
			prev->nameNext = newNode;
		}

		temp = weightFront;                                   // exactly the same as before but now we use the weight pointer to sort the list by weight
		while (temp->weightNext != 0 && temp->info <= data)   // Get into place and keep track of previous
		{
			prev = temp;
			temp = temp->weightNext;
		}

		if (weightFront->weightNext == NULL)								// adding to a list when only one node is sorted by weight
		{
			if (data < temp->info)						// stick before head
			{
				newNode->weightNext = weightFront;
				weightFront = newNode;
			}
			else										// stick after head
			{
				weightFront->weightNext = newNode;
			}
		}
		else if (temp == weightFront)							// adding to the front, same as namefront except by weight
		{
			newNode->weightNext = weightFront;
			prev = newNode;
			weightFront = newNode;
		}
		else											// or else add to the middle
		{
			newNode->weightNext = temp;
			prev->weightNext = newNode;
		}
	}


    void printAll() const // print all data by traversing through both pointer for name and weight
	{
		cout << "Sorted by Name" << endl << endl;
		for (Node *tmp = nameFront; tmp != 0; tmp = tmp->nameNext)
			cout << tmp->name << " " << tmp->info << endl;
		cout << endl << endl << "Sorted by Weight" << endl << endl;
		for (Node *tmp = weightFront; tmp != 0; tmp = tmp->weightNext)
			cout << tmp->name << " " << tmp->info << endl;
	}
};

int main (void)
{
	List theList; // instantiate new list
	string str; // string variable for name
	int x;  // int var for weight

	ifstream stream("C:\\Users\\Ivan Almazan\\desktop\\Names.txt"); // file we are reding from
	while(!stream.eof()) // To get all the lines while not at end of file.
	{
		stream >> str;  // Read the first item from the file into a string variable str.
		stream >> x;    // Read the second item from the file into an integer variable x.
		theList.insert(str, x); // add both name and weight into node that is then added to the tree
	}
	theList.printAll(); // print out list by name and weight
	system("pause"); // pause console output at end of program to see results
	return 0;
}

/*  OUTPUT

Sorted by Name

Abe 199
Annabelle 99
April 117
Bob 156
Bobby 109
Brian 150
Chris 175
Claire 124
Jason 182
Jim 150
Kevin 145
Michael 174
Richard 200
Steven 164
Tom 212


Sorted by Weight

Annabelle 99
Bobby 109
April 117
Claire 124
Kevin 145
Jim 150
Brian 150
Bob 156
Steven 164
Michael 174
Chris 175
Jason 182
Abe 199
Richard 200
Tom 212
Press any key to continue . . .
*/