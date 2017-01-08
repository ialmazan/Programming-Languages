/*Problem	1:	 Write	a	program	pipe_test which	creates	three	processes, P1, P2, P3
and	pipes	as	needed.The	first		process	displays	its	pid, prompts	the	user	for	a
string	and	then	sends	it	to	the	second	process.The	second	process		displays	its	pid,
displays	the	string	it	received, reverses	the	string, displays	the	reversed	string, and
sends	it	to	the	third	process.The	third	process	displays	its	pid, displays	the	string		it
received, converts	the	string	to	uppercase, displays	the	string	the	string	it
generated, and	sends		it	back	to	the	first	process.When	the	first	process	gets	the
processed	string, it	displays	its	pid	and	displays	the	string	it	received	it	to	the
terminal.When	all	this	is	done, all	processes	terminate		but	display	their	pid	and	a
message	announcing	their	imminent	death.*/

#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <errno.h>
#include <sys/types.h>
#include <signal.h>

char buffer1[256]; //msg1
char buffer2[256]; //msg2
char buffer3[256]; //msg3
struct sigaction sa;
char p; //global to keep track of p1, p2, p3

void perror(const char *s);

void toUpcase(char buff[], int n)
{
	int i;
	for (i = 0; i < n; i++)
	if (buff[i] >= 0x61)
		buff[i] -= 0x20;
}

void fatal(char * msg, int errcode)
{
	perror(msg);
	exit(errno);
}

void display(char buff[], int n)
{
	if (write(1, buff, n) == -1) // - displays the string it received,
		fatal("Unable to write to stdout", 1);
}

void reverse(char buff[], int n)
{
	int j = 0;
	char swap;
	for (j = 0; j < n / 2; j++) {
		swap = buff[n - 1 - j];
		buff[n - 1 - j] = buff[j];
		buff[j] = swap;
	}
}
int intToChars(char buff[], int val, int bufflen)
{
	int i = 0;
	while (val > 0 && i < bufflen) {
		buff[i++] = (char)(val % 10) + 0x30;
		val /= 10;
	}
	if (val > 0)
		fatal("integer exceeds buffer size", 1);
	reverse(buff, i);
	return i;
}

void printPid()
{
	int n;
	char decimal[256];
	display("\n", 1);
	display("I am process P", 14); //imm followed by p val
	write(1, &p, 1); //p will hold val of where it was called
	display("\n", 1);
	display("My pid is ", 10);
	n = intToChars(decimal, getpid(), 256); //convert pid to char so we use display to print it
	display(decimal, n);
	display("\n", 1);
}

void interruptHandler(int n)
{
	while (wait() != -1);
	printPid();
	display("I am about to die", 17);
	display("\n", 1);
}

int main()
{
	int A[2]; // pipe between p1 and p2
	int B[2]; // pipe between p2 and p3
	int C[2]; // pipe between p1 and p3
	pid_t pid;
	int msg1, msg2, msg3;

	sa.sa_handler = interruptHandler;
	sigaction(SIGUSR1, &sa, NULL);

	if ((pipe(A)) == -1)
		fatal("Unable to create pipe A", 1);
	if ((pipe(C)) == -1)
		fatal("Unable to create pipe B", 1);

	p = '1';

	switch (pid = fork()) {
	case -1:
		fatal("Unable to fork A", 1);
		break;
	case 0: // child : p2
		p = '2';
		close(C[0]); // close read pipe C
		close(A[1]); // close write end of pipe A
		if (pipe(B) == -1)
			fatal("Unable to create pipe B", 1);
		switch (pid = fork()) {
		case -1:
			fatal("Unable to fork B", 1);
			break;
		case 0: // child : p3
			p = '3';
			sigaction(SIGUSR1, &sa, NULL);
			close(B[1]); // close write end of pipe B
			if ((msg3 = read(B[0], buffer3, 256)) == -1) // read from pipe, blocking until parent supplies data
			{
				perror("can't read pipe");
				exit(1);
			}
			printPid();
			display("I just received the string ", 27);
			display(buffer3, msg3);
			display("\n", 1);
			toUpcase(buffer3, msg3);
			display("I am sending ", 13);
			display(buffer3, msg3);
			display(" to P1", 6);
			display("\n", 1);
			if (write(C[1], buffer3, msg3) == -1) //  send back to proc 1 that has been waiting for msg back
				fatal("Unable to write pipe c", 1);
			pause();
			break;
		default:
			close(C[1]); // close write end of pipe C
			close(B[0]); // close read end of pipe B
			if ((msg2 = read(A[0], buffer2, 256)) == -1) // read from pipe, blocking until parent supplies data
				fatal("Unable to read pipe", 1);
			printPid(); 
			display("I just received the string ", 27);
			display(buffer2, msg2);
			display("\n", 1);
			reverse(buffer2, msg2);
			display("I am sending ", 13);
			display(buffer2, msg2);
			display(" to P3", 6);
			display("\n", 1);
			if (write(B[1], buffer2, msg2) == -1) // sends msg the third process.
				fatal("Unable to write pipe b", 1);
			pause();
			break;
		}
		break;
	default: // parent : p1
		close(C[1]);
		printPid();
		display("Please enter a string: ", 24);
		if ((msg1 = read(0, buffer1, 256)) == -1)
			fatal("Unable to read stdin", 10);
		if (buffer1[0] == '\n')
		{
			display("Nothing Entered", 15);
			display("\n", 1);
			kill(0, SIGKILL);
		}
		if (write(A[1], buffer1, msg1 - 1) == -1) // write to pipe to send msg.
			fatal("Unable to write pipe a", 1);
		if ((msg1 = read(C[0], buffer1, 256)) == -1) //read from pipe when p3 return msg
			fatal("Unable to read pipe", 1);
		printPid();
		display("I just received the string ", 27);
		display(buffer1, msg1);
		display("\n", 1);

		kill(0, SIGUSR1);// Signal death to all that can recieve signal SIGUSR1
		break;
	}



}

