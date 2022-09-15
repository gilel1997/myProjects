#ifndef RATIONAL_HEADER
#define RATIONAL_HEADER
#include<stdio.h>
#include<cstring>
#include<string.h>
#include<conio.h>
#include<iostream>
#include "Polynomial.h"

using std::string;

class Rational
{
public:
	Rational();
	Rational(Polynomial p1, Polynomial p2);
	~Rational();
	void print();
	Polynomial getNom();
	Polynomial getDenom();
private:
	Polynomial p1;
	Polynomial p2;
	string polinomal1;
	string polinomal2;
};
#endif
