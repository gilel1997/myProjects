#ifndef POLYNOMIAL_HEADER
#define POLYNOMIAL_HEADER
#include<stdio.h>
#include<cstring>
#include<string.h>
#include<conio.h>
#include<iostream>

using namespace std;

class Polynomial
{
public:
	Polynomial(int degree);
	Polynomial();
	Polynomial(double* arryD, int degree);
	~Polynomial();
	int GetDegree();
	void SetDegree(int degree);
	double* GetArryD();
	void SetArryD(double* arryD, int degree);
	string GetPolynomial();
	void SetPolynomial(string polynomial);
	void print();
	double getDegree(bool what) const;
	void setCoeff(int degree, double num);
	double getCoeff(int index) const ;
	static int getMaxDegree();
	Polynomial operator + (Polynomial p1);
	Polynomial operator - (Polynomial p1);
	Polynomial operator * (Polynomial p1);
	Polynomial operator = (Polynomial p1);


private:
	int degree;
	string polynomial;
	double* arryD;
	static int maxDegree;
};
#endif


