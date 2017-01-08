/* 
Ivan Almazan
ID# 759511
Prof. Glenn Cuevas                                     Assignment 3
CS 41
*/

#include <iostream>
#include <string>
#include <fstream>

using namespace std;

class treeNode
{
public:
	string name; //name
	int data; // weight
	treeNode *left, *right; // links

	treeNode(string name = " ", int data = 0, treeNode *l = 0, treeNode *r = 0) //constructor with dfault values
	{
		this->name = name;
		this->data = data;
		left = l;
		right = r;
	}
};
	
class binarySearchTree
{
public:	
	treeNode *root; // our root for easy access
	float total;  // variables for finding max min and avg
	int count;
	int maximum;
	int minimum;

	binarySearchTree() //  default constructor which intializes everything to zero
	{
		root = 0;
		total = 0;
		count = 0;
		maximum = 0;
		minimum = 0;
	}


	bool addNode(string name = " ", int data = 0)
	{
		treeNode *newNode = new treeNode(name, data);			// our  new node
		if (root == 0)									// check for an empty root
		{
			root = newNode;
			return true;
		}
		treeNode *temp = root;							// create a temp node to traverse the list
		while(true)
		{
			if (name < temp->name)						// check to see if we will traverse to the left
				if (temp->left == 0)					// check to see if we have found newNode's position
				{
					temp->left = newNode;
					break;
				}
				else									// move to subtree
					temp = temp->left;
			else if (name > temp->name)					// check to see if we will traverse to the right
				if (temp->right == 0)					// check to see if we have found newNode's position
				{
					temp->right = newNode;
					break;
				}
				else									// move to subtree
					temp = temp->right;
			else if (name == temp->name)				// For this implementation, we will not allow duplicates
				return false; // no dupes
		}
		return true;
	}

	void inorderTraversal(treeNode *temp) // in-order traversal that traverses the tree in a left, visit, right pattern
	{
		if (temp != 0)
		{
			inorderTraversal(temp->left);			//  move to left subtree
			cout << temp->name << ' ' << temp->data << endl;				// print all data in current node
			inorderTraversal(temp->right);			// move to right subtree
		}
	}

	void preorderTraversal(treeNode *temp)  // pre-order traversal that traverses the tree in a visit, left, right pattern
	{
		if (temp != 0)
		{
			cout << temp->name << ' ' << temp->data << endl;				// print all data in current node
			preorderTraversal(temp->left);			// move to left subtree
			preorderTraversal(temp->right);			// move to right subtree
		}
	}

	void postorderTraversal(treeNode *temp)  //in-order traversal that traverses the tree in a left, right, visit pattern
	{
		if (temp != 0)
		{
			postorderTraversal(temp->left);			// move to left subtree
			postorderTraversal(temp->right);			// move to right subtree
			cout << temp->name << ' ' << temp->data << endl;				// print all data in current node
		}
	}
	
	int findHeight(treeNode *temp) // finds height of tree using recursion
	{
		//Empty node is in which case the height is -1
		if (temp == NULL)
		{
         return -1;
		}
		else          //else use recursion to find max height of subtrees and add 1 
		{
			return max(findHeight(temp->left), findHeight(temp->right)) + 1;
		}
	}

	int findLeaves(treeNode *temp )
	{
		if (temp == NULL ) // if tree doesn't exist
			return 0;
		if(temp->left == NULL && temp->right == NULL )// if root is a leaf return 1
			return 1;
		else    // if it isn't a leaf we will count all the leaves in the subtrees and return that value of the total amount using recursion
			return findLeaves(temp->left) + findLeaves(temp->right);
	}
	
	void search(string name)
	{    
		treeNode *p = root, *prev = 0; // search the tree while keeping track of the parent
		while (p != 0 && !(p->name == name)) 
		{
			prev = p;
			if (p->name < name)
				p = p->right;
			else p = p->left;
		}
		if (p != 0 && p->name == name) /// when found will print name and weight
			cout<< name <<"'s associated weight is "<< p->data << endl;
		else if (root != 0) // else it isn't in tree
			cout << name << " is not in the tree\n";
		else // incase tree is empty
			cout << "the tree is empty" << endl;
	}

	void findMaxMinAvg(treeNode *temp) // finds max, min, and avg, and keeps count of nodes
	{
		if (temp != 0) //same as preoder traversal but updates variables instead of printing values
		{
			if(temp->data > maximum) // upadte max if current data is greater
				maximum = temp->data;
			if(temp->data < minimum || minimum == 0) // update min if current data is less
				minimum = temp->data;
			total += temp->data; // add curent data to total
			count +=1; // update count for every node
			findMaxMinAvg(temp->left);
			findMaxMinAvg(temp->right);
		}
	}

	void extraCredit(treeNode *temp) // goes to far left since tree is already ordered from with the smallest name at the left
	{
		if(temp->left != NULL) // uses recursion until we get to farthest left value
			extraCredit(temp->left);
		else
			cout << "The first name in alphabetical order is " << temp->name << endl; // print name
	}

};

int main (void)
{
	binarySearchTree bst;
	string str;
	int x;
	bst.search("April"); // seaqrch but will come out as tree is empty because we have not built
	cout << endl;
	ifstream infile;
	infile.open ("C:\\Users\\Ivan Almazan\\desktop\\Names.txt"); // file we are reding from
	while(!infile.eof()) // To get all the lines.
	{
		infile >> str;  // Read the first item from the file into a string variable str.
		infile >> x;    // Read the second item from the file into an integer variable x.
		bst.addNode(str, x); // add both name and weight into node that is then added to the tree
	}
	infile.close();
	cout<< "In-order Traversal"<< endl;
	bst.inorderTraversal(bst.root); // pass root as starting point
	cout << endl;
	cout << "Pre-order Traversal"<< endl;
	bst.preorderTraversal(bst.root); // pass root as starting point
	cout << endl;
	cout << "Post-order Traversal"<< endl;
	bst.postorderTraversal(bst.root); // pass root as starting point
	cout << endl;
	bst.search("April"); // search for april
	bst.search("Ivan"); // search for ivan
	cout << endl;
	cout << "Height of tree is "<< bst.findHeight(bst.root) << endl << endl; // find the roots height
	cout << "There are " << bst.findLeaves(bst.root) << " leaves in the tree" << endl << endl; // find leaves in tree
	bst.findMaxMinAvg(bst.root); // find max, min, and avg starting at the root
	cout << "The max weight is " << bst.maximum << endl;
	cout << "The min weight is " << bst.minimum << endl;
	cout << "The average is "<< bst.total/bst.count << endl;
	cout << endl;
	bst.extraCredit(bst.root); // find first name in alphabetical order
	cout << endl;
	system("pause");
	return 0;
}

/* OUTPUT
the tree is empty

In-order Traversal
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

Pre-order Traversal
Jim 150
Abe 199
April 117
Annabelle 99
Claire 124
Bobby 109
Bob 156
Brian 150
Chris 175
Jason 182
Tom 212
Michael 174
Kevin 145
Richard 200
Steven 164

Post-order Traversal
Annabelle 99
Bob 156
Chris 175
Brian 150
Bobby 109
Jason 182
Claire 124
April 117
Abe 199
Kevin 145
Steven 164
Richard 200
Michael 174
Tom 212
Jim 150

April's associated weight is 117
Ivan is not in the tree

Height of tree is 6

There are 6 leaves in the tree

The max weight is 212
The min weight is 99
The average is 157.067

The first name in alphabetical order is Abe

Press any key to continue . . .
*/