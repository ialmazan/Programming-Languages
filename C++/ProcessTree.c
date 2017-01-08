/*Write	a	program	process_tree that	takes	a	single	integer	argument
n from	the	command	line	and	creates	a	binary	tree	of	processes	of	depth	n.When
the	tree	is	created, each	process, each	process	should	display	the	phrase
I am process x; my process pid is p(the	pid	for	process	x);
My parents pid is p1(the	pid	for	this	process’	parent)
After	printing	as	indicated	above, the	process	terminates.*/

#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <signal.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>

int n;
int status;
int x = 1;
int child1, child2;

int newNode(int);

void print()
{
	printf("I am process %d; my process pid is %d\n My parent's process pid is %d\n\n", x, getpid(), getppid());
}

int tree() {
	if (--n > 0) { // non-leaf node
		if ((child1 = newNode(2 * x)) == -1) //left child
			exit(errno);
		if (child1 && (child2 = newNode(2 * x + 1)) == -1) //right child
			exit(errno);
		if (child1 && child2) { // parent of left child and right child
			while (wait(&status) != -1); // wait until two children dead to print parent
			print();
		}
	}
	else { //print leaf nodes/ children
		print();
	}
}

int newNode(int refreshX)
{
	int pid;
	switch (pid = fork()) {
	case -1:
		perror("unable to fork");
		exit(1);
		break;
	case 0: // child
		x = refreshX;
		tree();
		break;
	default: // parent
		break;
	}
	return pid;
}

int main(int argc, char * argv[])
{
	if (argc < 2) {
		printf("Not enough aguments given \n");
		exit(1);
	}
	// Get user input
	sscanf(argv[1], "%d", &n); //put val n into global variable
	if (n == 0) {
		printf("Can't have tree of depth zero \n");
		exit(1);
	}
	printf("\n");
	tree();
	return 0;
}
