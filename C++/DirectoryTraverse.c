/*Write	a	program	directory_traverse_breadth_first that
takes	as	argument	a	path	to	a	directory	searching	for	a	file	name.To	convince	us
that	your	program	is	working	as intended, print	out	the	directory	and	file	names	it
encounters	in	the	search*/

#include <errno.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <unistd.h>
#include <fcntl.h>
#include <dirent.h>
#include <string.h>

int depth = 0;
int isDepthReached = 0;
struct stat status;
struct node_t {
	char * path;
	struct node_t * next;
};
struct node_t * queue;
struct node_t * queueEnd;

void enqueue (char * path) {
	struct node_t * node = (struct node_t *) malloc(sizeof(struct node_t));
	node->path = path;
	node->next = NULL;
	if (queueEnd)
		queueEnd->next = node;
	else
		queue = node;
	queueEnd = node;
}

int isDir (char * path)
{
	if (stat(path, &status)) {
		perror("Error in stat-ing entity");
		exit(errno);
	}
	return S_ISDIR(status.st_mode);
}

int main (int argc, char * argv[])
{
	DIR * dp;
	struct dirent * dip;
	char * fullpath = NULL;
	// check format or params
	if (argc < 3) {
		printf("Not enough Arguments Given \n");
		exit(1);
	}

	fullpath = malloc(strlen(argv[1] + 1));
	strcpy(fullpath, argv[1]);
	if (fullpath[strlen(fullpath)-1] == '/')
		fullpath[strlen(fullpath)-1] = '\0';
	enqueue(fullpath);
	printf("%s\n", queue->path);

	while (queue) {
		if (!(dp = opendir(queue->path))) {
			printf("Unable to open Directory \n");
			exit(1);
		}
		// iterate items in current directory
		while(dip = readdir(dp)) {
			if (0 == strcmp(".", dip->d_name) || 0 == strcmp("..", dip->d_name) )
				continue;
			// update path
			fullpath = malloc(strlen(queue->path) + strlen(dip->d_name) + 2);
			sprintf(fullpath, "%s/%s", queue->path, dip->d_name);
			// match found
			if (0 == strcmp(dip->d_name, argv[2])) {
				printf("%s\n", fullpath);
				exit(0); //exit once found
			}
			printf("%s\n", fullpath);
			// if no match but isdir, enqueue
			if (0 == access(fullpath, F_OK) && isDir(fullpath))
				enqueue(fullpath);
		}
		// close current dir and move to next one
		closedir(dp);
		struct node_t * prev = queue;
		queue = queue->next;
	}
	//reached the end of tree and file not found
	printf("File not found!\n");
	return 0;
}
