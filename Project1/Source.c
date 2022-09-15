#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<Math.h>

void main()
{
#define MaxNum 1024
	int toLong = 0;
	long n, number = 0, i = 0;
	while (toLong == 0)
	{
		printf("enter number: ");
		scanf("%ld", &n);
		if (n >= MaxNum)
		{
			printf("number to long\n");
		}
		else
		{
			toLong = 1;
		}
	}
	while (n > 0)
	{
		number +=(int) ((n % 2) * pow(10, i));
		n /= 2;
		i++;
	}
	printf("%ld", number);

}