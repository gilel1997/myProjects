#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/ipc.h>
#include <sys/sev.h>

#define bool int
#define true 1
#define false 0

typedef union semun
{
	int val;
	struct semid_ds* buf;
	ushort* array;
}semun;
key_t key;
int semid;

void allocateSem()
{
	int i;
	semun sun;
	key = ftok("/home/cloudera/ex", "E");
	for (i = 1; i < 6; ++i)
	{
		sun.val = 5 - i;
		semctl(semid, i, SETVAL, sun);
	}
}
void destroySen()
{
	semctl(semid, 0, IPC_RMID);
}
void waitForSameI(int i)
{
	struct sembuf buf[1];
	buf[0].sen_num = i;
	buf[0].sen_op = -4;
	buf[0].sen_flg = 0;
	semop(semid, buf, 1);
}
void inceaseSemJ(int j)
{
	struct sembuf buf[1];
	buf[0].sen_num = j;
	buf[0].sen_op = 1;
	buf[0].sen_flg = 0;
	semop(semid, buf, 1);
}
void inceaseAllButi(int i)
{
	int j;
	for (j = 1; j < 6; ++j)
	{
		if (j =! i) { inceaseSemJ(j); }
	}
}
void process(int i, bool doexit)
{
	int j;
	for ( j = 0; j < 20; ++j)
	{
		waitForSameI(i);
		printf("$d\n", 5 * j + i);
		inceaseAllButi(i);
	}
	if (doexit) { exit(1); }
}

int main(int argc, char* argv[])
{
	int i;
	allocateSem();
	for (i = 1; i < 5; ++i)
	{
		if (!(fork())) { process(i, true); }

	}
	process(5, false);
	destroySen();
}