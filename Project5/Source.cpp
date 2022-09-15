#include<iostream>
#include "Rational.h"



using std::cout;
using std::endl;

void main()
{
	Rational num1 = Rational(5, 8);
	Rational num2 = Rational(6, 7);
	Rational num3 = Rational();
	cout << num1<<endl;
	cout << num2 << endl;
	num3 = num1 + num2;
	cout << num3 << endl;


	
}