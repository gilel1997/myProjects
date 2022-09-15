#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <assert.h>
#include <Math.h>

int AbeforB(const char* c1, const char* c2)
{
	int length = 10;
	int i;
	for (i = 0; i < length; i++)
	{	
		if (c1[i] - c2[i] > 0)
		{
			return 0;
		}
	}
	return 1;
}
void main()
{

	int a = AbeforB("abcd", "bcd");
}
