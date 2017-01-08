/*Problem	2.		Write	a	program	AlrmTest that does	the	following.Creates	two	child
processes	that	each	increments	a	process - local	variable	count in	an infinite	loop.
The	parent	is	just	 a	for loop	of	5	iterations, where	in each	interation it sleeps	for	a
second	and	then	sends	the	SIGALRM signal	to	each	child.Upon	receiving	this
signal, each	child	is	to	print	out	the	value	of	count along	with	its	process	id	and
reset	the	count	to	zero.*/

#include <stdlib.h>
#include <errno.h>
#include <sys/types.h>
#include <signal.h>
#include <stdio.h>

pid_t child1id, child2id;
struct sigaction sa;
unsigned long int count = 0;

void perror(const char *s);

void display ()
{
	printf("Count is %lu, my pid is %d\n", count, getpid());
	count = 0;
}

void main ()
{
	sa.sa_handler = display;
	sigaction(SIGALRM, &sa, NULL);
	sigfillset(&sa.sa_mask);
	int i = 0;
	switch (child1id = fork()) {
		case -1:
			perror("Can't fork");
			exit(1);
			break;
		case 0: // child 1
			while (1)
				count ++;
			break;
		default: // parent
			switch (child2id = fork()) {
				case -1:
					perror("Can't fork");
					exit(1);
					break;
				case 0: // child 2
					while (1)
						count ++;
					break;
				default:
					for (i = 0; i < 6; i++) {
						sleep(1);
						kill(child1id, SIGALRM); //send sigalrm to child1
						kill(child2id, SIGALRM); //send sigalrm to child2
					}
					kill(child1id, SIGINT); //end child1
					kill(child2id, SIGINT); //end child2
					break;
			}
			break;
	}
}
