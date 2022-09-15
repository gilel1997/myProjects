#include<stdio.h>
#include <stdlib.h>

#define N 10
#define _CRT_SECURE_NO_DEPRECATE

typedef struct student_init_data
{
	unsigned long IdStudentNumber;
	int* gradeOfStudent;
	int numberOfTest;
}StudentInitData;

typedef struct student_processed_data
{
	unsigned long IdStudentNumber;
	double averegeGrade;
}StudentProcessedData;

typedef struct statistics
{
	StudentProcessedData* groupOne;
	StudentProcessedData* groupTwo;
	int n1;
	int n2;
	double averege;
}Statistics;

int* InputData(int n);
double StudentAverage(int* grades, int n);
double TotalAverage(double* avgers, int n);
void Classification(StudentInitData* students, Statistics* statistics, double* avgers);

void FreeMemory(int* grades, double* avgers, StudentProcessedData* groupOne, StudentProcessedData* groupTwo);

void main()
{
	int i, id;
	StudentInitData students[N];
	for (i = 0; i < N; i++)
	{
		printf("enter the ID of the student: ");
		scanf_s("%d", &students[i].IdStudentNumber);
		printf("\nenter the amount of test that this student will take: ");
		scanf_s("%d", &students[i].numberOfTest);
		printf("\n");
		students[i].gradeOfStudent = InputData(students[i].numberOfTest);
	}
}
int* InputData(int n)
{
	int i;
	int* grades = (int*)calloc(n, sizeof(int));
	printf("enter the grades of the student: ");
	for (i = 0; i < n; i++)
	{
		printf("\ngrades number %d: ", i + 1);
		scanf_s("%d", &(*(grades + i)));
	}
}
double StudentAverage(int* grades, int n)
{
	int i;
	double avg = 0;
	for (i = 0; i < n; i++)
	{
		avg += *(grades + i);
	}
	return (double)(avg / n);
}
double TotalAverage(double* avgers, int n)
{
	int i;
	double avg = 0;
	for (i = 0; i < n; i++)
	{
		avg += avgers[i];
	}
	return (double)(avg / n);
}
void Classification(StudentInitData* students, Statistics* statistics, double* avgers)
{
	int i, count = 0, n = N / 2;
	StudentProcessedData* groupOne = (StudentProcessedData*)calloc(n, sizeof(StudentProcessedData));
	StudentProcessedData* groupTwo = (StudentProcessedData*)calloc(n, sizeof(StudentProcessedData));
	for (i = 0; i < n; i++)
	{
		groupOne[i].IdStudentNumber = students[count].IdStudentNumber;
		groupOne[i].averegeGrade = StudentAverage(&students[count].gradeOfStudent, students[count].numberOfTest);
		count++;
		groupTwo[i].IdStudentNumber = students[count].IdStudentNumber;
		groupTwo[i].averegeGrade = StudentAverage(&students[count].gradeOfStudent, students[count].numberOfTest);

	}
	statistics->groupOne = groupOne;
	statistics->groupOne = groupTwo;
	statistics->n1 = n;
	statistics->n2 = n;
	statistics->averege = TotalAverage(&avgers, N);
}
void FreeMemory(int* grades, double* avgers, StudentProcessedData* groupOne, StudentProcessedData* groupTwo)
{
	free(grades);
	free(avgers);
	free(groupOne);
	free(groupTwo);
	grades = NULL;
	avgers = NULL;
	groupOne = NULL;
	groupTwo = NULL;
	return;
}

