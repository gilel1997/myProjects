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
				/*case 5: Ex5(); break;*/
			}
		} while (all_Ex_in_loop && select);
		return 0;
}


void Ex1()
{
	int a;
	printf("Enter number:\n");
	scanf_s("%d", &a);
	printf("the difference is: %d\n", DifferenceEvenFromOdd(a));
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
	function(a);
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
	if (SumHalfPow(a, b))
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
	SwapNumber(a);
}
void Ex5()
{
	int a;
	double x;
	printf("Enter number larger then 0:\n");
	scanf_s("%d", &a);
	printf("Enter number larger then 0:\n");
	scanf_s("%lf", &x);
	printf("the sum of the series of %d is: ", SumOfN(a, x));
}

int DifferenceEvenFromOdd(int a)
{
	int countEven = 0, countOdd = 0;
	while (a > 0)
	{
		if (a % 10 % 2 == 0)
		{
			countEven++;
		}
		else
		{
			countOdd++;
		}
		a /= 10;
	}
	return countEven - countOdd;
}
void function(int a)
{

	int i = 0, j = 0;
	while (7 * i <= a)
	{
		j = 0;
		while (2 * j <= a)
		{
			if (7 * i + 2 * j == a)
			{
				printf("(%d,%d)\n", i, j);
				break;
			}
			j++;
		}
		i++;
	}
}
int SumHalfPow(int n, int numOfDIgit)
{
	int firstHalf, secondHalf, divider, temp;
	divider = (int)pow(10, numOfDIgit / 2);
	firstHalf = n / divider;
	secondHalf = n % divider;
	if ((int)pow(firstHalf + secondHalf, 2) == n)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}
void SwapNumber(int n)
{
	int swapNumber = 0, i = 0;
	while (n > 0)
	{
		int temp = n % 10;
		if (temp == 1)
		{
			swapNumber += 9 * (int)pow(10, i);
		}
		else if (temp == 0)
		{
			swapNumber += 8 * (int)pow(10, i);
		}
		else
		{
			swapNumber += (temp - 2) * (int)pow(10, i);
		}
		i++;
		n /= 10;
	}
	printf("the swap number is: %d\n", swapNumber);
}
int SumOfN(int n, double x)
{
	int acheret = 1;
	double sum = 0;
	for (int i = 0; i <= n; i++)
	{
		if (i == 0)
		{
			sum += x - 1;
		}
		else
		{
			acheret *= (2 * i) + (2 * i + 1);
			sum += pow(x - 1, 2 * n - 1) / acheret * (n + 1);
		}
	}
	return sum;
}