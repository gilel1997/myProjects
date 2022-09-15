#include<stdio.h>
#include "Rational.h"
#include<iostream>
#include <string>

using namespace std;



Rational::Rational()
{
	polinomal1 = "0";
	polinomal2 = "1";
}
Rational::Rational(Polynomial p1Cpp, Polynomial p2Cpp)
{
	p1 = p1Cpp;
	p2 = p2Cpp;
	polinomal1 = p1.GetPolynomial();
	polinomal2 = p2.GetPolynomial();
}
Rational::~Rational()
{

}
void Rational::print()
{
	cout << polinomal1 << endl << "---------------" << endl;
	cout << polinomal2 << endl;
}
Polynomial Rational::getNom()
{
	return p1;
}
Polynomial Rational::getDenom()
{
	return p2;
}