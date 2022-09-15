#include<iostream>
#include "Rational.h"



using std::cout;
using std::endl;


Rational::Rational()
{
	numerator = 0;
	denominator = 1;//מפני שמכנה לא יכול להיות אפס
}
Rational::Rational(int numerator, int denominator)
{
	SetNumerator(numerator);
	SetDenominator(denominator);
	while (denominator == 0)
	{
		cout << "the denominator cant be 0 try enter agian" << endl;
		denominator = GetDenominator();
	}
}
Rational::~Rational()
{

}
void Rational::SetNumerator(int numerator)
{
	this->numerator = numerator;
}
void Rational::SetDenominator(int denominator)
{
	this->denominator = denominator;
}
int Rational::GetNumerator()
{
	return  this->numerator;
}
int Rational::GetDenominator()
{
	return  this->denominator;
}
Rational Rational::operator+(Rational num2)
{
	int temp1;
	Rational temp;
	if (this->denominator == num2.denominator)
	{
		temp.numerator = this->numerator + num2.numerator;
	}
	else
	{
		temp1 = this->denominator * num2.denominator;
		this->numerator *= num2.denominator;
		num2.numerator *= this->denominator;
		temp.numerator = this->numerator + num2.numerator;
		temp.denominator = temp1;
	}
	return temp;

}
Rational Rational::operator-(Rational num2)
{
	int temp1;
	Rational temp;
	if (this->denominator == num2.denominator)
	{
		temp.numerator = this->numerator - num2.numerator;
	}
	else
	{
		temp1 = this->denominator * num2.denominator;
		this->denominator = temp1;
		num2.denominator = temp1;
		this->numerator *= num2.denominator;
		num2.denominator *= this->denominator;
		temp.numerator = this->numerator - num2.numerator;
		temp.denominator = temp1;
	}
	return temp;
}
Rational Rational::operator*(Rational num2)
{
	Rational temp;
	temp.numerator = this->numerator * num2.numerator;
	temp.denominator = this->denominator * num2.denominator;
	return temp;
}
Rational Rational::operator/(Rational num2)
{
	Rational temp;
	temp.numerator = this->numerator * num2.denominator;
	temp.denominator = this->denominator * num2.numerator;
	return temp;
}
Rational Rational::operator!()
{
	Rational temp;
	temp.numerator = this->denominator;
	temp.denominator = this->numerator;
	return temp;
}
ostream& operator<<(ostream& output, const Rational& num)
{
	output << num.numerator << endl << "__" << endl << num.denominator<<endl;
	return output;
}
istream& operator>>(istream& input, Rational& num)
{
	input >> num.numerator >> num.denominator;
	return input;
}
