#include<iostream>
#include<sstream>
#include<string>
#include<math.h>

//ivan almazan
//912383996

using namespace std;

int toBaseTen(string number, int base)
{
	int power = number.length() - 1;
	int baseTen = 0;
	for (unsigned int i = 0; i < number.length(); i++)
	{
		if (number[i] >= 48 && number[i] <= 57)
		{
			int digit = number[i] - '0';
			baseTen += digit * pow(base, power);
		}
		else if (number[i] >= 65 && number[i] <= 90)
		{
			int digit = number[i] - '7';
			baseTen += digit * pow(base, power);
		}
		else
		cout << "Invalid Input " << endl;
		power--;
	}
	return baseTen;
}

string toNewBase(int baseTen, int newBase)
{
	string newNumber;
	ostringstream ss;
	int remainder = 0;
	while (baseTen != 0) 
	{
	remainder = baseTen % newBase;
		if (remainder >= 10)
		{
		ss.str(string());
		ss << (char)('A'+ remainder -10);
		newNumber += ss.str();
		}
		else
		{
		ss.str(string());
		ss << remainder;
		newNumber += ss.str();
		}
	baseTen = baseTen / newBase;
	}
	return newNumber = string(newNumber.rbegin(),newNumber.rend());
}

int main()
{
	string number, newNumber = " ";
	int base, newBase, baseTen = 0;

	cout << "Please enter the number's base: ";
	cin >> base;
	cout << "Please enter the number: ";
	cin >> number;
	cout << "Please enter the new base: ";
	cin >> newBase;
	baseTen = toBaseTen(number, base);
	newNumber = toNewBase(baseTen, newBase);
	cout << number << " base " << base << " is " << newNumber << " base " << newBase << endl;
	
	return 0;
}
