#include<stdio.h>
#include "Polynomial.h"
#include<iostream>
#include <string>

using namespace std;

int Polynomial::maxDegree;
Polynomial::Polynomial(int degreeCpp)
{
	arryD = new double[degreeCpp];
	int len = sizeof(double) * (degreeCpp + 1);
	memset(arryD, 0, len);
	degree = degreeCpp;
	SetArryD(arryD, degree);
	
}
Polynomial::Polynomial()
{
	degree = 0;
	arryD = new double[degree];
	memset(arryD, 0, sizeof(int) * degree);
	polynomial = "0";
	maxDegree = 0;
}
Polynomial::Polynomial(double* arryDCpp, int degree)
{
	arryD = new double[degree];
	for (int i = 0; i <= degree; i++)
	{
		if (i == 0)
		{
			polynomial = to_string(arryDCpp[i]);
		}
		else
		{
			polynomial += "+" + to_string(arryDCpp[i]) + "x^ " + to_string(i);
		}
	}
	maxDegree = degree - 1;
}

Polynomial::~Polynomial()
{

}

int Polynomial::getMaxDegree()
{
	return maxDegree;
}
int Polynomial::GetDegree()
{
	return degree;
}
void Polynomial::SetDegree(int degreeCpp)
{
	degree = degreeCpp;
}
string Polynomial::GetPolynomial()
{
	return polynomial;
}
void Polynomial::SetPolynomial(string polynomialCpp)
{
	polynomial = polynomialCpp;
}
double* Polynomial::GetArryD()
{
	return arryD;
}
void Polynomial::SetArryD(double* arryDCpp, int degree)
{
	polynomial = "0";
	for (int i = 0; i < degree; i++)
	{
		polynomial += "+" + to_string(arryDCpp[i + 1]) + "x^ " + to_string(i+ 1);
	}
	maxDegree = degree - 1;
}
void Polynomial::print()
{
	cout << "Polynomial = " << polynomial << endl;
}
void Polynomial::setCoeff(int degreeCpp, double num)
{
	arryD[degreeCpp] = num;
	bool ifEmpty = true;
	for (int i = 0; i < degree; i++)
	{
		if (arryD[i] != 0)
		{
			ifEmpty = false;
		}
		
	}
	if (ifEmpty)
	{
		polynomial = "0";
		return;
	}
	SetArryD(arryD, degree);
}
double Polynomial::getCoeff(int index) const
{
	return 0;
}
double Polynomial::getDegree(bool what) const
{
	return degree;
}
Polynomial Polynomial::operator + (Polynomial p1)
{
	Polynomial pTemp();
	if (this->arryD > p1.arryD)
	{
		int length = sizeof(this->arryD) / sizeof(*this->arryD);
		for (int i = 0; i < length; i++)
		{
			pTemp. this->arryD
		}
	}
	else
	{

	}
}
Polynomial Polynomial::operator - (Polynomial p1)
{

}
Polynomial Polynomial::operator * (Polynomial p1)
{

}
Polynomial Polynomial::operator = (Polynomial p1)
{

}
