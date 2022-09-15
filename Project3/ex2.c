// Gil Elazar 318651924
#include <stdio.h>
#include <Math.h>
/* Function declarations */
void Ex1();
void Ex2();
void Ex3();
void Ex4();
void Ex5();

/* Declarations of other functions */
int DifferenceEvenFromOdd(int);
void function(int);
int SumHalfPow(int, int);
void SwapNumber(int);
int SumOfN(int, double);

int main()
{
	int select = 0, i, all_Ex_in_loop = 0;
	printf("Run menu once or cyclically?\n(Once - enter 0, cyclically - enter other number) ");
	if (scanf_s("%d", &all_Ex_in_loop) == 1)
		do
		{
			for (i = 1; i <= 5; i++)
				printf("Ex%d--->%d\n", i, i);
			printf("EXIT-->0\n");
			do {
				select = 0;
				printf("please select 0-5 : ");
				scanf_s("%d", &select);
			} while ((select < 0) || (select > 5));
			switch (select)
			{
			case 1: Ex1(); break;
			case 2: Ex2(); break;
			case 3: Ex3(); break;
			case 4: Ex4(); break;
			case 5: Ex5(); break;
			}
		} while (all_Ex_in_loop && select);
		return 0;
}


void Ex1()
{
	int a;
	printf("Enter number:\n");
	scanf_s("%d", &a);
	if (IsNumberHaveEvenDigit(a) == 1)
	{
		printf("the number %d has an even digit\n", a);
	}
	else 
	{
		printf("the number %d has not have even digit\n", a);
	}
}
void Ex2()
{
	int a;
	printf("Enter number that larger then 7\n");
	scanf_s("%d", &a);
	while (a <= 7)
	{
		printf("your number is smaller then 7 try again\n");
		scanf_s("%d", &a);
	}
	//function(a);
}
void Ex3()
{
	int a, b = 0, temp;
	printf("Enter number:\n");
	scanf_s("%d", &a);
	temp = a;
	while (temp > 0)
	{
		temp /= 10;
		b++;
	}
	if (1)
	{
		printf("the number satisfies the condition");
	}
	else
	{
		printf("the number does'nt satisfies the condition");
	}
}
void Ex4()
{
	int a;
	printf("Enter number:\n");
	scanf_s("%d", &a);
	//SwapNumber(a);
}
void Ex5()
{
	int a;
	double x;
	printf("Enter number larger then 0:\n");
	scanf_s("%d", &a);
	printf("Enter number larger then 0:\n");
	scanf_s("%lf", &x);
	//printf("the sum of the series of %d is: ", SumOfN(a, x));
}
int IsNumberHaveEvenDigit(int num)
{
	if (num == 0)
	{
		return 1;
	}
	return IsEvenDigit(num % 10) && IsEvenDigit(IsNumberHaveEvenDigit(num / 10) % 10);
}
int IsEvenDigit(int digit)
{
	return digit % 2 == 0;
}