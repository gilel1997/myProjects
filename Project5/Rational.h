#ifndef RATIONAL_H
#define RATIONAL_H

#include<iostream>
using std::ostream;
using std::istream;


class Rational
{
	friend ostream& operator<<(ostream&, const Rational& );
	friend istream& operator>>(istream&, Rational& );
private:
	int numerator;//מונה
	int denominator;//מכנה
public:
	Rational();
	Rational(int numerator, int denominator);
	~Rational();
	void SetNumerator(int numerator);
	void SetDenominator(int denominator);
	int GetNumerator();
	int GetDenominator();
	Rational operator+(Rational num2);
	Rational operator-(Rational num2);
	Rational operator*(Rational num2);
	Rational operator/(Rational num2);
	Rational operator!();


};
#endif